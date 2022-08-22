using Application.Functions.User.Commands.RegisterUserWithRolesCommand;
using MediatR;

namespace Application.Functions.Workers.Commands.UpdateWorker
{
    public class UpdateWorkerCommand : IRequest<UpdateWorkerResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddres { get; set; }
        public string NewPassword { get; set; }
        public string NewAccessKey { get; set; }
        public string NewSecretKey { get; set; }
        public int? IdWorksite { get; set; }

        public ICollection<RoleDTO> UserRoles { get; set; }
    }
}
