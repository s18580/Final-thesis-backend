using MediatR;

namespace Application.Functions.User.Commands.RegisterUserCommand
{
    public class RegisterUserCommand : IRequest<RegisterUserResponse>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddres { get; set; }
        public string Password { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public int? IdWorksite { get; set; }
    }
}
