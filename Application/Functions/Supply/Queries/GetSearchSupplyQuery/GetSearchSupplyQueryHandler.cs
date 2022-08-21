using Application.Functions.DTOs.SearchersDTOs;
using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supply.Queries.GetSearchSupplyQuery
{
    public class GetSearchSupplyQueryHandler : IRequestHandler<GetSearchSupplyQuery, List<SearchSupplyDTO>>
    {
        private readonly IApplicationContext _context;

        public GetSearchSupplyQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<SearchSupplyDTO>> Handle(GetSearchSupplyQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Models.Supply> supplies = new List<Domain.Models.Supply>();
            if (request.SupplierName.Equals("null") && request.RepresentativeName.Equals("null") && request.SupplyItemTypeName.Equals("null") && request.SupplyDate.Equals("null"))
            {
                supplies = await _context.Supplies
                                         .Include(m => m.SupplyItemType)
                                         .Include(m => m.OrderItem.Order)
                                         .ThenInclude(m => m.Representative)
                                         .ThenInclude(m => m.Supplier)
                                         .Where(b => b.IsReceived == request.IsReceived)
                                         .ToListAsync();
            }
            else
            {
                //Date format
                var requestSupplyDate = DateTime.Parse(request.SupplyDate);
                supplies = await _context.Supplies
                                         .Include(m => m.SupplyItemType)
                                         .Include(m => m.OrderItem.Order)
                                         .ThenInclude(m => m.Representative)
                                         .ThenInclude(m => m.Supplier)
                                         .Where(b => b.IsReceived == request.IsReceived)
                                         .Where(b => b.SupplyDate == requestSupplyDate || b.SupplyItemType.Name == request.SupplyItemTypeName || (b.OrderItem.Order.Representative.Name + " " + b.OrderItem.Order.Representative.Name) == request.RepresentativeName || b.OrderItem.Order.Representative.Supplier.Name == request.SupplierName)
                                         .ToListAsync();
            }

            var suppliesDTO = new List<SearchSupplyDTO>();

            foreach (Domain.Models.Supply supply in supplies)
            {
                var supplyDTO = new SearchSupplyDTO
                {
                    IdSupply = supply.IdSupply,
                    SupplyDate = supply.SupplyDate,
                    OrderName = supply.OrderItem.Order.Name,
                    SupplierName = supply.OrderItem.Order.Representative.Supplier.Name,
                    RepresentativeName = supply.OrderItem.Order.Representative.Name + " " + supply.OrderItem.Order.Representative.LastName,
                    SupplyType = supply.SupplyItemType.Name,
                    IsReceived = supply.IsReceived
                };

                suppliesDTO.Add(supplyDTO);
            }

            return suppliesDTO;
        }
    }
}
