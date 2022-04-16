using MediatR;

namespace Application.Functions.Representative.Commands.DeleteRepresentativeCommand
{
    public class DeleteRepresentativeCommand : IRequest<DeleteRepresentativeResponse>
    {
        public int IdRepresentative { get; set; }
    }
}
