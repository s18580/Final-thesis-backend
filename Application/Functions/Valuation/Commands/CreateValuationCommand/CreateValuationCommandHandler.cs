using Application.Functions.DTOs.DTOsValidators;
using Application.Services;
using AutoMapper;
using Domain.Enumerators;
using MediatR;

namespace Application.Functions.Valuation.Commands.CreateValuationCommand
{
    public class CreateValuationCommandHandler : IRequestHandler<CreateValuationCommand, CreateValuationResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateValuationCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateValuationResponse> Handle(CreateValuationCommand request, CancellationToken cancellationToken)
        {
            // create validators
            var validator = new CreateValuationValidator(_context);
            var paperValidator = new PaperDTOValidator(_context);
            var serviceValidator = new ServiceDTOValidator(_context);

            // validate data
            var validatorResult = await validator.ValidateAsync(request);
            if (!validatorResult.IsValid) return new CreateValuationResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            foreach (var paper in request.Papers)
            {
                var paperValidatorResult = await paperValidator.ValidateAsync(paper);
                if (!paperValidatorResult.IsValid) return new CreateValuationResponse(paperValidatorResult, Responses.ResponseStatus.ValidationError);
            }

            foreach (var service in request.Services)
            {
                var serviceValidatorResult = await serviceValidator.ValidateAsync(service);
                if (!serviceValidatorResult.IsValid) return new CreateValuationResponse(serviceValidatorResult, Responses.ResponseStatus.ValidationError);
            }

            // create objects in transaction
            int IdValuation;

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                var newValuation = new Domain.Models.Valuation
                {
                    Name = request.Name,
                    Recipient = request.Recipient,
                    CreationDate = DateTime.Now,
                    OfferValidityDate = request.OfferValidityDate,
                    InsideCirculation = request.InsideCirculation,
                    Capacity = request.Capacity,
                    InsideFormat = request.InsideFormat,
                    CoverFormat = request.CoverFormat,
                    InsideSheetFormat = request.InsideSheetFormat,
                    CoverSheetFormat = request.CoverSheetFormat,
                    InsideSheetNumber = request.InsideSheetNumber,
                    CoverSheetNumber = request.CoverSheetNumber,
                    InsideOther = request.InsideOther,
                    CoverOther = request.CoverOther,
                    CoverCirculation = request.CoverCirculation,
                    InsidePlateNumber = request.InsidePlateNumber,
                    CoverPlateNumber = request.CoverPlateNumber,
                    MainCirculation = request.MainCirculation,
                    FinalPrice = request.FinalPrice,
                    IdAuthor = request.IdAuthor,
                    IdOrderItem = request.IdOrderItem,
                    IdBindingType = request.IdBindingType,
                };

                await _context.Valuations.AddAsync(newValuation);
                await _context.SaveChangesAsync();

                foreach (var color in request.Colors)
                {
                    var newColor = new Domain.Models.Color
                    {
                        Name = color.Name,
                        IsForCover = color.IsForCover,
                        IdOrderItem = null,
                        IdValuation = newValuation.IdValuation,
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
                        IdOrderItem = null,
                        IdValuation = newValuation.IdValuation,
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
                        IsForCover = service.IsForCover,
                        IdOrderItem = null,
                        IdValuation = newValuation.IdValuation,
                    };

                    await _context.Services.AddAsync(newService);
                    await _context.SaveChangesAsync();
                }

                foreach (var priceList in request.ValuationPriceLists)
                {
                    var newPriceList = new Domain.Models.ValuationPriceList
                    {
                        UsedPrice = priceList.UsedPrice,
                        IdPriceList = priceList.IdPriceList,
                        IdValuation = newValuation.IdValuation,
                    };

                    await _context.ValuationPriceLists.AddAsync(newPriceList);
                    await _context.SaveChangesAsync();
                }

                IdValuation = newValuation.IdValuation;

                dbContextTransaction.Commit();
            }

            return new CreateValuationResponse(IdValuation);
        }
    }
}
