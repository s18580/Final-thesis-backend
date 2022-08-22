using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Workers.Commands.UpdateWorker
{
    public class UpdateWorkerCommandHandler : IRequestHandler<UpdateWorkerCommand, UpdateWorkerResponse>
    {
        private readonly IApplicationContext _context;
        private readonly IAuthenticationService _authentication;

        public UpdateWorkerCommandHandler(IApplicationContext context, IAuthenticationService authentication)
        {
            _context = context;
            _authentication = authentication;
        }

        public async Task<UpdateWorkerResponse> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateWorkerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateWorkerResponse(validatorResult, Responses.ResponseStatus.ValidationError);



            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                var selectedWorker = await _context.Workers.Include(m => m.RoleAssignments).Where(p => p.IdWorker == request.Id).SingleAsync();

                if (selectedWorker.Name != request.Name) { selectedWorker.Name = request.Name; }
                if (selectedWorker.LastName != request.LastName) { selectedWorker.LastName = request.LastName; }
                if (selectedWorker.PhoneNumber != request.PhoneNumber) { selectedWorker.PhoneNumber = request.PhoneNumber; }
                if (selectedWorker.EmailAddres != request.EmailAddres) { selectedWorker.EmailAddres = request.EmailAddres; }
                if (selectedWorker.IdWorksite != request.IdWorksite) { selectedWorker.IdWorksite = request.IdWorksite; }
                if (selectedWorker.AccessKeyAWS != request.NewAccessKey) { selectedWorker.AccessKeyAWS = request.NewAccessKey; }
                if (selectedWorker.SecretKeyAWS != request.NewSecretKey) { selectedWorker.SecretKeyAWS = request.NewSecretKey; }

                //reset password
                if (!request.NewPassword.Equals(string.Empty))
                {
                    byte[] salt, passHash;
                    _authentication.CreatePasswordHash(request.NewPassword, out passHash, out salt);

                    selectedWorker.RefreshToken = "";
                    selectedWorker.Password = passHash;
                    selectedWorker.Salt = salt;
                }

                await _context.SaveChangesAsync();

                //looking for roles ro delete
                foreach (var roleAssignment in selectedWorker.RoleAssignments)
                {
                    var toDelete = true;
                    foreach (var role in request.UserRoles)
                    {
                        if (roleAssignment.IdRole == role.IdRole)
                        {
                            toDelete = false;
                        }
                    }

                    if (toDelete)
                    {
                        _context.RoleAssignments.Remove(roleAssignment);
                        await _context.SaveChangesAsync();
                    }
                }

                //looking for roles to add
                foreach (var role in request.UserRoles)
                {
                    var toAdd = true;
                    foreach (var roleAssignment in selectedWorker.RoleAssignments)
                    {
                        if (roleAssignment.IdRole == role.IdRole)
                        {
                            toAdd = false;
                        }
                    }

                    if (toAdd)
                    {
                        var newRoleAssignment = new Domain.Models.RoleAssignment
                        {
                            IdRole = role.IdRole,
                            IdWorker = selectedWorker.IdWorker,
                        };

                        await _context.RoleAssignments.AddAsync(newRoleAssignment);
                        await _context.SaveChangesAsync();
                    }
                }

                dbContextTransaction.Commit();
            }

            return new UpdateWorkerResponse();
        }
    }
}