using MediatR;

namespace Application.Functions.Address.Commands.DisableAddressCommand
{
    public class DisableAddressCommand : IRequest<DisableAddressResponse>
    {
        public int Id { get; set; }
        public bool IsDisabled { get; set; }
    }
}
