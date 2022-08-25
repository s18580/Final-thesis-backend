namespace Application.Functions.DTOs.SearchersDTOs
{
    public class SearchOrderDTO
    {
        public int IdOrder { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string DeliveryDate { get; set; }
        public string OrderStatus { get; set; }
        public string RepresentativeName { get; set; }
        public string Workers { get; set; }
        public string OrderItemTypes { get; set; }
        public bool IsAuction { get; set; }
    }
}
