using MediatR;

namespace Application.Functions.SupplyItemType.Commands.CreateSupplyItemTypeCommand
{
    public class CreateSupplyItemTypeCommand : IRequest<CreateSupplyItemTypeResponse>
    {
        public string Name { get; set; }
    }
}
