using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supply.Queries.GetSupplyListQuery
{
    public class GetSupplyListQueryHandler : IRequestHandler<GetSupplyListQuery, List<Domain.Models.Supply>>
    {
        private readonly IApplicationContext _context;

        public GetSupplyListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.Supply>> Handle(GetSupplyListQuery request, CancellationToken cancellationToken)
        {
            var supplies = await _context.Supplies
                                         .ToListAsync();

            return supplies;
        }
    }
}
