using Application.Functions.DTOs.SearchersDTOs;
using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Valuation.Queries.GetSearchValuationListQuery
{
    public class GetSearchValuationListQueryHandler : IRequestHandler<GetSearchValuationListQuery, List<SearchValuationDTO>>
    {
        private readonly IApplicationContext _context;

        public GetSearchValuationListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<SearchValuationDTO>> Handle(GetSearchValuationListQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Models.Valuation> valuations = new List<Domain.Models.Valuation>();
            if (request.ValuationName.Equals("null") && request.Author.Equals("null") && request.Paper.Equals("null") && request.Color.Equals("null") && request.ServiceName.Equals("null") && request.BindingType.Equals("null") && request.OrderName.Equals("null") && request.OrderItemType.Equals("null") && request.OrderItem.Equals("null") && request.CreationDate.Equals("null"))
            {
                valuations = await _context.Valuations
                                           .Include(m => m.Author)
                                           .Include(m => m.OrderItem)
                                           .ThenInclude(m => m.Order)
                                           .Include(m => m.OrderItem)
                                           .ThenInclude(m => m.OrderItemType)
                                           .ToListAsync();
            }
            else
            {
                var dateToCheck = DateTime.Parse(request.CreationDate);
                valuations = await _context.Valuations
                                           .Include(m => m.Author)
                                           .Include(m => m.OrderItem)
                                           .ThenInclude(m => m.Order)
                                           .Include(m => m.OrderItem)
                                           .ThenInclude(m => m.OrderItemType)
                                           .Where(p => p.Name == request.ValuationName || p.Author.Name + " " + p.Author.LastName == request.Author || p.CreationDate == dateToCheck || p.BindingType.Name == request.BindingType ||
                                                  p.Papers.Where(p => p.Name == request.Paper).Count() > 0 || p.Colors.Where(p => p.Name == request.Color).Count() > 0 || p.Services.Where(p => p.ServiceName.Name == request.ServiceName).Count() > 0 || 
                                                  p.OrderItem.Order.Name == request.OrderName || p.OrderItem.OrderItemType.Name == request.OrderItemType || p.OrderItem.Name == request.OrderItem)
                                           .ToListAsync();
            }

            var valuationsDTO = new List<SearchValuationDTO>();
            foreach (Domain.Models.Valuation valuation in valuations)
            {
                if (valuation.OrderItem == null)
                {
                    var valuationDTO = new SearchValuationDTO
                    {
                        IdValuation = valuation.IdValuation,
                        Name = valuation.Name,
                        Author = valuation.Author.Name + " " + valuation.Author.LastName,
                        PrintPrice = valuation.FinalPrice.ToString(),
                        OrderName = "",
                        OrderItemTypes = "",
                    };

                    valuationsDTO.Add(valuationDTO);
                }
                else
                {
                    var valuationDTO = new SearchValuationDTO
                    {
                        IdValuation = valuation.IdValuation,
                        Name = valuation.Name,
                        Author = valuation.Author.Name + " " + valuation.Author.LastName,
                        PrintPrice = valuation.FinalPrice.ToString(),
                        OrderName = valuation.OrderItem.Order.Name,
                        OrderItemTypes = valuation.OrderItem.Name,
                    };

                    valuationsDTO.Add(valuationDTO);
                }
            }

            return valuationsDTO;
        }
    }
}
