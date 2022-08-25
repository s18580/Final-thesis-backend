namespace Application.Functions.DTOs
{
    public class SupplyDTO
    {
        public string ItemDescription { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }
        public DateTime SupplyDate { get; set; }
        public bool IsReceived { get; set; }
        public int IdSupplyItemType { get; set; }
        public int IdRepresentative { get; set; }
        public int IdOrderItem { get; set; }

        public ICollection<DeliveriesAddressesDTO> DeliveriesAddresses { get; set; }
    }
}
