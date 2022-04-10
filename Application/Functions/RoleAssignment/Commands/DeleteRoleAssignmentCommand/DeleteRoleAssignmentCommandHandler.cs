using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.RoleAssignment.Commands.DeleteRoleAssignmentCommand
{
    public class DeleteRoleAssignmentCommandHandler : IRequestHandler<DeleteRoleAssignmentCommand, DeleteRoleAssignmentResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteRoleAssignmentCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteRoleAssignmentResponse> Handle(DeleteRoleAssignmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteRoleAssignmentValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteRoleAssignmentResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var roleAssignmentToDelete = await _context.RoleAssignments
                                                       .Where(p => p.IdRole == request.IdRole)
                                                       .Where(p => p.IdWorker == request.IdWorker)
                                                       .SingleAsync();

            _context.RoleAssignments.Remove(roleAssignmentToDelete);
            await _context.SaveChangesAsync();

            return new DeleteRoleAssignmentResponse();
        }
    }
}
