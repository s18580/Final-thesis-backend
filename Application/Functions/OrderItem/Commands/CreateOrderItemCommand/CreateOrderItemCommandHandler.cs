using Application.Functions.DTOs.DTOsValidators;
using Application.Services;
using AutoMapper;
using Domain.Enumerators;
using MediatR;

namespace Application.Functions.OrderItem.Commands.CreateOrderItemCommand
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, CreateOrderItemResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateOrderItemCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateOrderItemResponse> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            // create validators
            var paperValidator = new PaperDTOValidator(_context);
            var serviceValidator = new ServiceDTOValidator(_context);
            var orderItemValidator = new CreateOrderItemValidator(_context);

            // validate data
            var validatorResult = await orderItemValidator.ValidateAsync(request);
            if (!validatorResult.IsValid) return new CreateOrderItemResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            foreach (var paper in request.Papers)
            {
                var paperValidatorResult = await paperValidator.ValidateAsync(paper);
                if (!paperValidatorResult.IsValid) return new CreateOrderItemResponse(paperValidatorResult, Responses.ResponseStatus.ValidationError);
            }

            foreach (var service in request.Services)
            {
                var serviceValidatorResult = await serviceValidator.ValidateAsync(service);
                if (!serviceValidatorResult.IsValid) return new CreateOrderItemResponse(serviceValidatorResult, Responses.ResponseStatus.ValidationError);
            }

            // create objects in transaction
            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                var newOrderItem = new Domain.Models.OrderItem
                {
                    IdOrder = request.IdOrder,
                    Circulation = request.Circulation,
                    Capacity = request.Capacity,
                    Name = request.Name,
                    Comments = request.Comments,
                    ExpectedCompletionDate = request.ExpectedCompletionDate,
                    CompletionDate = request.CompletionDate,
                    InsideFormat = request.InsideFormat,
                    CoverFormat = request.CoverFormat,
                    IdDeliveryType = request.IdDeliveryType,
                    IdBindingType = request.IdBindingType,
                    IdOrderItemType = request.IdOrderItemType,
                };

                await _context.OrderItems.AddAsync(newOrderItem);
                await _context.SaveChangesAsync();

                foreach (var color in request.Colors)
                {
                    var newColor = new Domain.Models.Color
                    {
                        Name = color.Name,
                        IsForCover = color.IsForCover,
                        IdOrderItem = newOrderItem.IdOrderItem,
                        IdValuation = null,
                    };

                    await _context.Colors.AddAsync(newColor);
                    await _context.SaveChangesAsync();
                }

                foreach (var paper in request.Papers)
                {
                    FiberDirection fiberD;
                    if (paper.FiberDirection == FiberDirection.Poziomy.ToString())
                    {
                        fiberD = FiberDirection.Poziomy;
                    }
                    else
                    {
                        fiberD = FiberDirection.Pionowy;
                    }

                    var newPaper = new Domain.Models.Paper
                    {
                        Name = paper.Name,
                        Kind = paper.Kind,
                        SheetFormat = paper.SheetFormat,
                        IsForCover = paper.IsForCover,
                        Opacity = paper.Opacity,
                        FiberDirection = fiberD,
                        PricePerKilogram = paper.PricePerKilogram,
                        Quantity = paper.Quantity,
                        IdOrderItem = newOrderItem.IdOrderItem,
                        IdValuation = null,
                    };

                    await _context.Papers.AddAsync(newPaper);
                    await _context.SaveChangesAsync();
                }

                foreach (var service in request.Services)
                {
                    var newService = new Domain.Models.Service
                    {
                        Price = service.Price,
                        IdServiceName = service.IdServiceName,
                        IdOrderItem = newOrderItem.IdOrderItem,
                        IdValuation = null,
                    };

                    await _context.Services.AddAsync(newService);
                    await _context.SaveChangesAsync();
                }

                dbContextTransaction.Commit();
            }

            return new CreateOrderItemResponse();
        }
    }
}
