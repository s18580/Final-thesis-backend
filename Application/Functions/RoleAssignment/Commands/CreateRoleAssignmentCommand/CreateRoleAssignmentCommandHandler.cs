using Application.Services;
using AutoMapper;
using MediatR;

namespace Application.Functions.RoleAssignment.Commands.CreateRoleAssignmentCommand
{
    public class CreateRoleAssignmentCommandHandler : IRequestHandler<CreateRoleAssignmentCommand, CreateRoleAssignmentResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IMapper _mapper;

        public CreateRoleAssignmentCommandHandler(IApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateRoleAssignmentResponse> Handle(CreateRoleAssignmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateRoleAssignmentValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new CreateRoleAssignmentResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var newRoleAssignment = _mapper.Map<Domain.Models.RoleAssignment>(request);

            await _context.RoleAssignments.AddAsync(newRoleAssignment);
            await _context.SaveChangesAsync();

            return new CreateRoleAssignmentResponse(newRoleAssignment.IdWorker, newRoleAssignment.IdRole);
        }
    }
}
