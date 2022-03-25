namespace Domain.Models.DictionaryModels
{
    public class OrderItemType
    {
        public int IdOrderItemType { get; set; }
        public string Name { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
