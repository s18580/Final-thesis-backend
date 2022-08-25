using Application.Services;
using Domain.Models;
using MediatR;

namespace Application.Functions.User.Commands.RegisterUserWithRolesCommand
{
    public class RegisterUserWithRolesCommandHandler : IRequestHandler<RegisterUserWithRolesCommand, RegisterUserWithRolesResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IAuthenticationService _authentication;

        public RegisterUserWithRolesCommandHandler(IApplicationContext context, IAuthenticationService authentication)
        {
            _context = context;
            _authentication = authentication;
        }

        public async Task<RegisterUserWithRolesResponse> Handle(RegisterUserWithRolesCommand request, CancellationToken cancellationToken)
        {
            var validator = new RegisterUserWithRolesValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new RegisterUserWithRolesResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            byte[] salt, passHash;
            _authentication.CreatePasswordHash(request.Password, out passHash, out salt);

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                var newWorker = new Worker
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    PhoneNumber = request.PhoneNumber,
                    EmailAddres = request.EmailAddres,
                    IdWorksite = request.IdWorksite,
                    AccessKeyAWS = request.AccessKey,
                    SecretKeyAWS = request.SecretKey,
                };
                newWorker.RefreshToken = "";
                newWorker.Password = passHash;
                newWorker.Salt = salt;
                newWorker.IsDisabled = false;

                await _context.Workers.AddAsync(newWorker);
                await _context.SaveChangesAsync();

                foreach (var role in request.UserRoles)
                {
                    var newRoleAssignment = new Domain.Models.RoleAssignment
                    {
                        IdRole = role.IdRole,
                        IdWorker = newWorker.IdWorker,
                    };

                    await _context.RoleAssignments.AddAsync(newRoleAssignment);
                    await _context.SaveChangesAsync();
                }

                dbContextTransaction.Commit();
            }

            return new RegisterUserWithRolesResponse();
        }
    }
}
