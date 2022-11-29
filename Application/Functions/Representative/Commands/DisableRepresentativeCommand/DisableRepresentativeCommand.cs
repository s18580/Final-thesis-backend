using MediatR;

namespace Application.Functions.Representative.Commands.DisableRepresentativeCommand
{
    public class DisableRepresentativeCommand : IRequest<DisableRepresentativeResponse>
    {
        public int Id { get; set; }
        public bool IsDisabled { get; set; }
    }
}
