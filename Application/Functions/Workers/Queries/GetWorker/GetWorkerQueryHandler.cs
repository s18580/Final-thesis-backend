using Application.Services;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Workers.Queries.GetWorker
{
    public class GetWorkerQueryHandler : IRequestHandler<GetWorkerQuery, Worker>
    {
        private readonly IApplicationContext _context;

        public GetWorkerQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<Worker> Handle(GetWorkerQuery request, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                       .Where(p => p.IdWorker == request.Id)
                                       .SingleOrDefaultAsync();

            return worker;
        }
    }
}
