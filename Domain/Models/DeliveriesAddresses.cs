namespace Domain.Models
{
    public class DeliveriesAddresses
    {
        public int IdDeliveriesAddresses { get; set; }
        public int IdAddress { get; set; }
        public int? IdOrder { get; set; }
        public int? IdSupply { get; set; }

        public Address Address { get; set; }
        public Order Order { get; set; }
        public Supply Supply { get; set; }
    }
}
