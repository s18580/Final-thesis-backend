using Application.Services;
using AutoMapper;
using Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Workers.Queries.GetWorkersList
{
    public class GetWorkersListQueryHandler : IRequestHandler<GetWorkersListQuery, List<WorkerDTO>>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public GetWorkersListQueryHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<WorkerDTO>> Handle(GetWorkersListQuery request, CancellationToken cancellationToken)
        {
            var workers = await _context.Workers.ToListAsync();
            List<WorkerDTO> workersDTO = new List<WorkerDTO>();

            foreach(Worker w in workers)
            {
                workersDTO.Add(_mapper.Map<WorkerDTO>(w));
            }

            return workersDTO;
        }
    }
}
