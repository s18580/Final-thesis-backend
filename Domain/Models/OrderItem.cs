using Domain.Models.DictionaryModels;

namespace Domain.Models
{
    public class OrderItem
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

        public Order Order { get; set; }
        public OrderItemType OrderItemType { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public BindingType? BindingType { get; set; }
        public ICollection<Color> Colors { get; set; }
        public ICollection<Paper> Papers { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<Valuation> Valuations { get; set; }
        public ICollection<Supply> Supplies { get; set; }
    }
}
