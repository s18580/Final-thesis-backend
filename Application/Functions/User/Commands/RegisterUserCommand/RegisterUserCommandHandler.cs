using Application.Services;
using AutoMapper;
using Domain.Models;
using MediatR;

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

            byte[] salt, passHash;
            _authentication.CreatePasswordHash(request.Password, out passHash, out salt);

            var newWorker = _mapper.Map<Worker>(request);
            newWorker.RefreshToken = "";
            newWorker.Password = passHash;
            newWorker.Salt = salt;
            newWorker.IsDisabled = false;

            await _context.Workers.AddAsync(newWorker);
            await _context.SaveChangesAsync();

            return new RegisterUserResponse(newWorker.IdWorker);
        }
    }
}
