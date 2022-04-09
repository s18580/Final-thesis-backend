using Application.Services;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Workers.Queries.GetWorkersList
{
    public class GetWorkersListQueryHandler : IRequestHandler<GetWorkersListQuery, List<Worker>>
    {
        private readonly IApplicationContext _context;

        public GetWorkersListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Worker>> Handle(GetWorkersListQuery request, CancellationToken cancellationToken)
        {
            var workers = await _context.Workers.ToListAsync();
            return workers;
        }
    }
}
