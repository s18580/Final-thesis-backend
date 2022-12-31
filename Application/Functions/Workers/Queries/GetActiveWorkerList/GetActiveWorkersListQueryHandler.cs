using Application.Services;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Workers.Queries.GetActiveWorkerList
{
    public class GetActiveWorkersListQueryHandler : IRequestHandler<GetActiveWorkersListQuery, List<WorkerDTO>>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public GetActiveWorkersListQueryHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<WorkerDTO>> Handle(GetActiveWorkersListQuery request, CancellationToken cancellationToken)
        {
            var workers = await _context.Workers.Include(b => b.Worksite).Where(p=>p.IsDisabled == false).ToListAsync();
            List<WorkerDTO> workersDTO = new List<WorkerDTO>();

            foreach (Worker w in workers)
            {
                var mappedWorker = _mapper.Map<WorkerDTO>(w);
                if (mappedWorker.Worksite != null)
                {
                    mappedWorker.Worksite.Workers = null;
                }
                workersDTO.Add(mappedWorker);
            }

            return workersDTO;
        }
    }
}
