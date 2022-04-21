using MediatR;

namespace Application.Functions.Address.Commands.DeleteAddressCommand
{
    public class DeleteAddressCommand : IRequest<DeleteAddressResponse>
    {
        public int IdAddress { get; set; }
    }
}
