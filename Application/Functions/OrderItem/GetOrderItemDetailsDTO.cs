namespace Application.Functions.OrderItem
{
    public class GetOrderItemDetailsDTO
    {
        public int IdOrderItem { get; set; }
        public int IdOrder { get; set; }
        public int Circulation { get; set; }
        public int? Capacity { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string InsideFormat { get; set; }
        public string CoverFormat { get; set; }
        public int IdDeliveryType { get; set; }
        public int? IdBindingType { get; set; }
        public int IdOrderItemType { get; set; }

        public Domain.Models.Order Order { get; set; }
        public Domain.Models.DictionaryModels.OrderItemType OrderItemType { get; set; }
        public Domain.Models.DictionaryModels.DeliveryType DeliveryType { get; set; }
        public Domain.Models.DictionaryModels.BindingType? BindingType { get; set; }
        public ICollection<Domain.Models.Color> Colors { get; set; }
        public ICollection<GetPaperDTO> Papers { get; set; }
        public ICollection<GetServiceDTO> Services { get; set; }
        public ICollection<Domain.Models.Valuation> Valuations { get; set; }
        public ICollection<Domain.Models.Supply> Supplies { get; set; }
    }
}
