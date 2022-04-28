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
        private readonly IMapper _mapper;

        public LoginUserQueryHandler(IApplicationContext context, IAuthenticationService authentication, IAuthorizationService authorization, IMapper mapper)
        {
            _context = context;
            _authentication = authentication;
            _authorization = authorization;
            _mapper = mapper;
        }

        public async Task<LoginUserResponse> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var validator = new LoginUserValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new LoginUserResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var worker = await _context.Workers
                                       .Where(p => p.EmailAddres == request.anonymousUserData.Email)
                                       .SingleAsync();

            if (worker.IsDisabled)
            {
                return new LoginUserResponse("Worker is disabled.", false, Responses.ResponseStatus.ValidationError);
            }

            var isValidUser = _authentication.VerifyPassword(request.anonymousUserData.Email, request.anonymousUserData.Password, worker.PassHash, worker.Salt);

            if (!isValidUser)
            {
                return new LoginUserResponse("Invalid email or password.", false, Responses.ResponseStatus.NotFound);
            }

            var user = _mapper.Map<LoggedUserDTO>(worker);

            var token = _authorization.CreateUserToken(user);

            return new LoginUserResponse(token);
        }
    }
}
