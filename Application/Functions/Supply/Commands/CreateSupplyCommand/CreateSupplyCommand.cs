using MediatR;

namespace Application.Functions.Supply.Commands.CreateSupplyCommand
{
    public class CreateSupplyCommand : IRequest<CreateSupplyResponse>
    {
        public string ItemDescription { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public DateTime SupplyDate { get; set; }
        public bool IsReceived { get; set; }
        public int IdSupplyItemType { get; set; }
        public int IdRepresentative { get; set; }
        public int IdOrderItem { get; set; }
    }
}
