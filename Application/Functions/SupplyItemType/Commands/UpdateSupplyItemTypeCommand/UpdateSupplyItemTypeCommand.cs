using MediatR;

namespace Application.Functions.SupplyItemType.Commands.UpdateSupplyItemTypeCommand
{
    public class UpdateSupplyItemTypeCommand : IRequest<UpdateSupplyItemTypeResponse>
    {
        public int IdSupplyItemType { get; set; }
        public string Name { get; set; }
    }
}
