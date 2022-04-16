using MediatR;

namespace Application.Functions.Representative.Commands.CreateRepresentativeCommand
{
    public class CreateRepresentativeCommand : IRequest<CreateRepresentativeResponse>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int IdOwner { get; set; }
    }
}
