using Application.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Workers.Queries.GetWorker
{
    public class GetWorkerQueryHandler : IRequestHandler<GetWorkerQuery, WorkerDTO>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public GetWorkerQueryHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<WorkerDTO> Handle(GetWorkerQuery request, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                       .Include(m => m.Worksite)
                                       .Include(m => m.RoleAssignments)
                                       .ThenInclude(m => m.Role)
                                       .Where(p => p.IdWorker == request.Id)
                                       .SingleOrDefaultAsync();

            var workerDTO = _mapper.Map<WorkerDTO>(worker);

            foreach(var roleAssignment in workerDTO.RoleAssignments)
            {
                roleAssignment.Role.RoleAssignments = null;
                roleAssignment.Worker = null;
            }

            return workerDTO;
        }
    }
}
