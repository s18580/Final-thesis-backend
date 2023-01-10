using Application.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.User.Queries.LoginUserQuery
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginUserResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IAuthenticationService _authentication;
        private readonly IAuthorizationService _authorization;

        public LoginUserQueryHandler(IApplicationContext context, IAuthenticationService authentication, IAuthorizationService authorization, IMapper mapper)
        {
            _context = context;
            _authentication = authentication;
            _authorization = authorization;
        }

        public async Task<LoginUserResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var validator = new LoginUserValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new LoginUserResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var worker = await _context.Workers
                                       .Where(p => p.EmailAddres == request.Email)
                                       .SingleAsync();

            if (worker.IsDisabled)
            {
                return new LoginUserResponse("Worker is disabled.", false, Responses.ResponseStatus.ValidationError);
            }

            var isValidUser = _authentication.VerifyPassword(request.Password, worker.Password, worker.Salt);

            if (!isValidUser)
            {
                return new LoginUserResponse("Invalid email or password.", false, Responses.ResponseStatus.NotFound);
            }

            var roleAssignments = await _context.RoleAssignments.Include(p => p.Role).Include(p => p.Worker).Where(p => p.Worker.IdWorker == worker.IdWorker).ToListAsync();
            var userRoles = new List<string>();
            foreach (Domain.Models.RoleAssignment assignment in roleAssignments)
            {
                userRoles.Add(assignment.Role.Name);
            }

            var token = _authorization.CreateUserToken(request.Email, userRoles);
            var refreshToken = _authorization.CreateRefreshToken();
            /*
            worker.RefreshToken = refreshToken.Token;
            worker.TokenCreated = refreshToken.Created;
            worker.TokenExpires = refreshToken.Expires;

            await _context.SaveChangesAsync();

            */
            return new LoginUserResponse(token, refreshToken, worker.Name + " " + worker.LastName, userRoles, worker.IdWorker);
        }
    }
}
