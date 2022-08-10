using MediatR;

namespace Application.Functions.User.Commands.RegisterUserWithRolesCommand
{
    public class RegisterUserWithRolesCommand : IRequest<RegisterUserWithRolesResponse>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddres { get; set; }
        public string Password { get; set; }
        public int? IdWorksite { get; set; }

        public ICollection<RoleDTO> UserRoles { get; set; }
    }
}
