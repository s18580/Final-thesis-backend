namespace Application.Functions.DTOs.SearchersDTOs
{
    public class SearchSupplyDTO
    {
        public int IdSupply { get; set; }
        public DateTime SupplyDate { get; set; }
        public string OrderName { get; set; }
        public string SupplierName { get; set; }
        public string RepresentativeName { get; set; }
        public string SupplyType { get; set; }
        public bool IsReceived { get; set; }
    }
}
