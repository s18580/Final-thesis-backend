namespace Domain.Models.DictionaryModels
{
    public class BindingType
    {
        public int IdBindingType { get; set; }
        public string Name { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
        public ICollection<Valuation> Valuations { get; set; }
    }
}
