using Domain.Models.DictionaryModels;

namespace Domain.Models
{
    public class Supply
    {
        public int IdSupply { get; set; }
        public string ItemDescription { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public DateTime SupplyDate { get; set; }
        public bool IsReceived { get; set; }
        public int IdSupplyItemType { get; set; }
        public int IdRepresentative { get; set; }
        public int IdOrderItem { get; set; }

        public SupplyItemType SupplyItemType { get; set; }
        public Representative Representative { get; set; }
        public ICollection<DeliveriesAddresses> DeliveriesAddresses { get; set; }
        public OrderItem OrderItem { get; set; }
    }
}
