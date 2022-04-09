using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, UpdateRoleResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateRoleCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateRoleResponse> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRoleValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateRoleResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedRole = await _context.Roles.Where(p => p.IdRole == request.Id).SingleAsync();

            if (selectedRole.Name != request.Name) { selectedRole.Name = request.Name; }

            await _context.SaveChangesAsync();

            return new UpdateRoleResponse();
        }
    }
}
