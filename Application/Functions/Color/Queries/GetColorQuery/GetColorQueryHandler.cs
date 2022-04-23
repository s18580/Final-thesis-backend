using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Color.Queries.GetColorQuery
{
    public class GetColorQueryHandler : IRequestHandler<GetColorQuery, Domain.Models.Color>
    {
        private readonly IApplicationContext _context;

        public GetColorQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Domain.Models.Color> Handle(GetColorQuery request, CancellationToken cancellationToken)
        {
            var color = await _context.Colors
                                      .Where(p => p.IdColor == request.IdColor)
                                      .SingleOrDefaultAsync();

            return color;
        }
    }
}
