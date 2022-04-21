using MediatR;

namespace Application.Functions.Supply.Commands.DeleteSupplyCommand
{
    public class DeleteSupplyCommand : IRequest<DeleteSupplyResponse>
    {
        public int IdSupply { get; set; }
    }
}
