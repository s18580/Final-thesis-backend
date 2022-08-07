using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.User.Commands.RefreshTokenCommand
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IAuthorizationService _authorization;

        public RefreshTokenCommandHandler(IApplicationContext context, IAuthorizationService authorization)
        {
            _context = context;
            _authorization = authorization;
        }

        public async Task<RefreshTokenResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var validator = new RefreshTokenValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new RefreshTokenResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var worker = await _context.Workers
                                       .Where(p => p.EmailAddres == request.userEmail)
                                       .SingleAsync();

            var roleAssignments = await _context.RoleAssignments.Include(p => p.Role).Include(p => p.Worker).Where(p => p.Worker.IdWorker == worker.IdWorker).ToListAsync();
            var userRoles = new List<string>();
            foreach (Domain.Models.RoleAssignment assignment in roleAssignments)
            {
                userRoles.Add(assignment.Role.Name);
            }

            var token = _authorization.CreateUserToken(request.userEmail, userRoles);
            var refreshToken = _authorization.CreateRefreshToken();

            worker.RefreshToken = refreshToken.Token;
            worker.TokenCreated = refreshToken.Created;
            worker.TokenExpires = refreshToken.Expires;

            await _context.SaveChangesAsync();

            return new RefreshTokenResponse(token, refreshToken);
        }
    }
}
