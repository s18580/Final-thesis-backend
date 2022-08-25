using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supply.Queries.GetSupplyListByRepresetnativeQuery
{
    public class GetSupplyListByRepresetnativeQueryHandler : IRequestHandler<GetSupplyListByRepresetnativeQuery, List<Domain.Models.Supply>>
    {
        private readonly IApplicationContext _context;

        public GetSupplyListByRepresetnativeQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Models.Supply>> Handle(GetSupplyListByRepresetnativeQuery request, CancellationToken cancellationToken)
        {
            var supplies = await _context.Supplies
                                         .Where(p => p.IdRepresentative == request.Id)
                                         .ToListAsync();

            return supplies;
        }
    }
}
