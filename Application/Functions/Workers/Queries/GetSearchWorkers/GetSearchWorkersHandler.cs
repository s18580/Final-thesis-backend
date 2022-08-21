using Application.Functions.DTOs.SearchersDTOs;
using Application.Services;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Workers.Queries.GetSearchWorkers
{
    public class GetSearchWorkersHandler : IRequestHandler<GetSearchWorkers, List<SearchWorkerDTO>>
    {
        private readonly IApplicationContext _context;

        public GetSearchWorkersHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<SearchWorkerDTO>> Handle(GetSearchWorkers request, CancellationToken cancellationToken)
        {
            List<Worker> workers = new List<Worker>();
            if (request.Name.Equals("null") && request.LastName.Equals("null") && request.WorksiteName.Equals("null"))
            {
                workers = workers = await _context.Workers
                                                  .Include(b => b.Worksite)
                                                  .ToListAsync();
            }
            else
            {
                workers = workers = await _context.Workers
                                                  .Include(b => b.Worksite)
                                                  .Where(b => b.Name == request.Name || b.LastName == request.LastName || b.Worksite.Name == request.WorksiteName)
                                                  .ToListAsync();
            }

            var workersDTO = new List<SearchWorkerDTO>();

            foreach (Worker worker in workers)
            {
                var worksite = "Brak stanowiska";
                if (worker.Worksite != null)
                {
                    worksite = worker.Worksite.Name;
                } 

                var workerDTO = new SearchWorkerDTO
                {
                    IdWorker = worker.IdWorker,
                    Name = worker.Name,
                    LastName = worker.LastName,
                    PhoneNumber = worker.PhoneNumber,
                    EmailAddres = worker.EmailAddres,
                    WorksiteName = worksite
                };

                workersDTO.Add(workerDTO);
            }

            return workersDTO;
        }
    }
}
