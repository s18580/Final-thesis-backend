using Application.Services;
using Domain.Enumerators;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItem.Commands.UpdateOrderItemCommand
{
    public class UpdateOrderItemCommandHandler : IRequestHandler<UpdateOrderItemCommand, UpdateOrderItemResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateOrderItemCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateOrderItemResponse> Handle(UpdateOrderItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateOrderItemValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateOrderItemResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedOrderItem = await _context.OrderItems
                                                  .Include(p => p.Colors)
                                                  .Include(p => p.Papers)
                                                  .Include(p => p.Services)
                                                  .Where(p => p.IdOrderItem == request.IdOrderItem)
                                                  .SingleAsync();

            if (selectedOrderItem.Name != request.Name) { selectedOrderItem.Name = request.Name; }
            if (selectedOrderItem.Circulation != request.Circulation) { selectedOrderItem.Circulation = request.Circulation; }
            if (selectedOrderItem.Capacity != request.Capacity) { selectedOrderItem.Capacity = request.Capacity; }
            if (selectedOrderItem.Comments != request.Comments) { selectedOrderItem.Comments = request.Comments; }
            if (selectedOrderItem.ExpectedCompletionDate != request.ExpectedCompletionDate) { selectedOrderItem.ExpectedCompletionDate = request.ExpectedCompletionDate; }
            if (selectedOrderItem.CompletionDate != request.CompletionDate) { selectedOrderItem.CompletionDate = request.CompletionDate; }
            if (selectedOrderItem.InsideFormat != request.InsideFormat) { selectedOrderItem.InsideFormat = request.InsideFormat; }
            if (selectedOrderItem.CoverFormat != request.CoverFormat) { selectedOrderItem.CoverFormat = request.CoverFormat; }
            if (selectedOrderItem.IdDeliveryType != request.IdDeliveryType) { selectedOrderItem.IdDeliveryType = request.IdDeliveryType; }
            if (selectedOrderItem.IdBindingType != request.IdBindingType) { selectedOrderItem.IdBindingType = request.IdBindingType; }
            if (selectedOrderItem.IdOrderItemType != request.IdOrderItemType) { selectedOrderItem.IdOrderItemType = request.IdOrderItemType; }

            foreach (var color in selectedOrderItem.Colors)
            {
                if (!request.Colors.Any(p => p.IdColor == color.IdColor))
                {
                    selectedOrderItem.Colors.Remove(color);
                }
            }
            await _context.SaveChangesAsync();


            foreach (var paper in selectedOrderItem.Papers)
            {
                if (!request.Papers.Any(p => p.IdPaper == paper.IdPaper))
                {
                    selectedOrderItem.Papers.Remove(paper);
                }
            }
            await _context.SaveChangesAsync();

            foreach (var service in selectedOrderItem.Services)
            {
                if (!request.Services.Any(p => p.IdService == service.IdService))
                {
                    selectedOrderItem.Services.Remove(service);
                }
            }
            await _context.SaveChangesAsync();

            foreach (var color in request.Colors)
            {
                if (selectedOrderItem.Colors.Any(p=>p.IdColor == color.IdColor))
                {
                    var c = selectedOrderItem.Colors.Where(p=>p.IdColor == color.IdColor).First();
                    if (c.Name != color.Name) { c.Name = color.Name; }
                    if (c.IsForCover != color.IsForCover) { c.IsForCover = color.IsForCover; }
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var newC = new Domain.Models.Color
                    {
                        Name = color.Name,
                        IsForCover = color.IsForCover,
                        IdOrderItem = selectedOrderItem.IdOrderItem
                    };

                    _context.Colors.Add(newC);
                    await _context.SaveChangesAsync();
                }
            }

            foreach (var paper in request.Papers)
            {
                if (selectedOrderItem.Papers.Any(p => p.IdPaper == paper.IdPaper))
                {
                    var p = selectedOrderItem.Papers.Where(p => p.IdPaper == paper.IdPaper).First();
                    if (p.Name != paper.Name) { p.Name = paper.Name; }
                    if (p.Kind != paper.Kind) { p.Kind = paper.Kind; }
                    if (p.SheetFormat != paper.SheetFormat) { p.SheetFormat = paper.SheetFormat; }
                    if (p.FiberDirection != (FiberDirection)paper.FiberDirection) { p.FiberDirection = (FiberDirection)paper.FiberDirection; }
                    if (p.Opacity != paper.Opacity) { p.Opacity = paper.Opacity; }
                    if (p.IsForCover != paper.IsForCover) { p.IsForCover = paper.IsForCover; }
                    if (p.PricePerKilogram != paper.PricePerKilogram) { p.PricePerKilogram = paper.PricePerKilogram; }
                    if (p.Quantity != paper.Quantity) { p.Quantity = paper.Quantity; }
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var newP = new Domain.Models.Paper
                    {
                        Name = paper.Name,
                        Kind = paper.Kind,
                        SheetFormat = paper.SheetFormat,
                        FiberDirection = (FiberDirection)paper.FiberDirection,
                        Opacity = paper.Opacity,
                        IsForCover = paper.IsForCover,
                        PricePerKilogram = paper.PricePerKilogram,
                        Quantity = paper.Quantity,
                        IdOrderItem = selectedOrderItem.IdOrderItem
                    };

                    selectedOrderItem.Papers.Add(newP);
                    await _context.SaveChangesAsync();
                }
            }

            foreach (var service in request.Services)
            {
                if (selectedOrderItem.Services.Any(p => p.IdService == service.IdService))
                {
                    var s = selectedOrderItem.Services.Where(p => p.IdService == service.IdService).First();
                    if (s.Price != service.Price) { s.Price = service.Price; }
                    if (s.IsForCover != service.IsForCover) { s.IsForCover = service.IsForCover; }
                    if (s.IdServiceName != service.IdServiceName) { s.IdServiceName = service.IdServiceName; }
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var newS = new Domain.Models.Service
                    {
                        Price = service.Price,
                        IsForCover = service.IsForCover,
                        IdServiceName = service.IdServiceName,
                        IdOrderItem = selectedOrderItem.IdOrderItem
                    };

                    selectedOrderItem.Services.Add(newS);
                    await _context.SaveChangesAsync();
                }
            }

            return new UpdateOrderItemResponse();
        }
    }
}
