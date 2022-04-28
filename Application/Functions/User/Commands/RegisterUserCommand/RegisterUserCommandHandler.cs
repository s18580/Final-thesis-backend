using Application.Services;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.User.Commands.RegisterUserCommand
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisterUserResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IAuthenticationService _authentication;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IApplicationContext context, IAuthenticationService authentication, IMapper mapper)
        {
            _context = context;
            _authentication = authentication;
            _mapper = mapper;
        }

        public async Task<RegisterUserResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new RegisterUserValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new RegisterUserResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var worker = await _context.Workers
                                       .Include(p => p.RoleAssignments)
                                       .Where(p => p.EmailAddres == request.anonymousUserData.Email)
                                       .SingleAsync();

            byte[] salt, passHash;
            _authentication.CreatePasswordHash(request.anonymousUserData.Password, out passHash, out salt);

            worker.PassHash = passHash;
            worker.Salt = salt;

            await _context.SaveChangesAsync();

            var user = _mapper.Map<LoggedUserDTO>(worker);

            return new RegisterUserResponse(user);
        }
    }
}
