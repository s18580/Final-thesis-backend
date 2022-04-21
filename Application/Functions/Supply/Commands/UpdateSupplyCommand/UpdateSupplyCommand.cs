using MediatR;

namespace Application.Functions.Supply.Commands.UpdateSupplyCommand
{
    public class UpdateSupplyCommand : IRequest<UpdateSupplyResponse>
    {
        public int IdSupply { get; set; }
        public string ItemDescription { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public DateTime SupplyDate { get; set; }
        public bool IsReceived { get; set; }
        public int IdSupplyItemType { get; set; }
        public int IdRepresentative { get; set; }
    }
}
