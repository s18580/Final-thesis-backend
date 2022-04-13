using Application.Services;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Application.Functions.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, DeleteRoleResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteRoleCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteRoleResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteRoleValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteRoleResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var roleToDelete = await _context.Roles
                                             .Where(p => p.IdRole == request.Id)
                                             .SingleAsync();

            _context.Roles.Remove(roleToDelete);
            await _context.SaveChangesAsync();

            return new DeleteRoleResponse();
        }
    }
}
