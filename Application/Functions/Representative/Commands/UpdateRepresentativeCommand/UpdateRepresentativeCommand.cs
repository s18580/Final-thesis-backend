using MediatR;

namespace Application.Functions.Representative.Commands.UpdateRepresentativeCommand
{
    public class UpdateRepresentativeCommand : IRequest<UpdateRepresentativeResponse>
    {
        public int IdRepresentative { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }
}
