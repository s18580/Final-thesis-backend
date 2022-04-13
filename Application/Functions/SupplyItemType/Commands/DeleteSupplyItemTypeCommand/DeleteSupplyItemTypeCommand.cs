using MediatR;

namespace Application.Functions.SupplyItemType.Commands.DeleteSupplyItemTypeCommand
{
    public class DeleteSupplyItemTypeCommand : IRequest<DeleteSupplyItemTypeResponse>
    {
        public int IdSupplyItemType { get; set; }
    }
}
