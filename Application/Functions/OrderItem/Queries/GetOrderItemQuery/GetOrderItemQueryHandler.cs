using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.OrderItem.Queries.GetOrderItemQuery
{
    public class GetOrderItemQueryHandler : IRequestHandler<GetOrderItemQuery, GetOrderItemDetailsDTO>
    {
        private readonly IApplicationContext _context;

        public GetOrderItemQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetOrderItemDetailsDTO> Handle(GetOrderItemQuery request, CancellationToken cancellationToken)
        {
            var orderItem = await _context.OrderItems
                                          .Include(p => p.BindingType)
                                          .Include(p => p.Colors)
                                          .Include(p => p.Papers)
                                          .Include(p => p.OrderItemType)
                                          .Include(p => p.DeliveryType)
                                          .Include(p => p.Services)
                                          .ThenInclude(p => p.ServiceName)
                                          .Where(p => p.IdOrderItem == request.IdOrderItem)
                                          .SingleOrDefaultAsync();

            List<GetPaperDTO> preparedPapers = new List<GetPaperDTO>();
            foreach (var paper in orderItem.Papers)
            {
                var paperDTO = new GetPaperDTO
                {
                    IdPaper = paper.IdPaper,
                    Name = paper.Name,
                    Kind = paper.Kind,
                    SheetFormat = paper.SheetFormat,
                    FiberDirection = paper.FiberDirection.ToString(),
                    Opacity = paper.Opacity,
                    IsForCover = paper.IsForCover,
                    PricePerKilogram = paper.PricePerKilogram,
                    Quantity = paper.Quantity,
                    IdValuation = paper.IdValuation,
                    IdOrderItem = paper.IdOrderItem,
                };

                preparedPapers.Add(paperDTO);
            }

            List<GetServiceDTO> preparedServices = new List<GetServiceDTO>();
            foreach (var service in orderItem.Services)
            {
                var serviceDTO = new GetServiceDTO
                {
                    IdService = service.IdService,
                    Price = service.Price,
                    IsForCover = service.IsForCover,
                    IdOrderItem = service.IdOrderItem,
                    IdValuation = service.IdValuation,
                    IdServiceName = service.IdServiceName,
                    ServiceName = service.ServiceName,
                    Name = service.ServiceName.Name,
                };

                preparedServices.Add(serviceDTO);
            }

            return new GetOrderItemDetailsDTO
            {
                IdOrderItem = orderItem.IdOrderItem,
                IdOrder = orderItem.IdOrder,
                Circulation = orderItem.Circulation,
                Capacity = orderItem.Capacity,
                Name = orderItem.Name,
                Comments = orderItem.Comments,
                ExpectedCompletionDate = orderItem.ExpectedCompletionDate,
                CompletionDate = orderItem.CompletionDate,
                InsideFormat = orderItem.InsideFormat,
                CoverFormat = orderItem.CoverFormat,
                IdDeliveryType = orderItem.IdDeliveryType,
                IdBindingType = orderItem.IdBindingType,
                IdOrderItemType = orderItem.IdOrderItemType,
                Order = orderItem.Order,
                OrderItemType = orderItem.OrderItemType,
                DeliveryType = orderItem.DeliveryType,
                BindingType = orderItem.BindingType,
                Colors = orderItem.Colors,
                Papers = preparedPapers,
                Services = preparedServices,
                Valuations = orderItem.Valuations,
                Supplies = orderItem.Supplies,
            };
        }
    }
}
