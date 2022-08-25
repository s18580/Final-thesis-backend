namespace Domain.Models.DictionaryModels
{
    public class OrderStatus
    {
        public int IdStatus { get; set; }
        public string Name { get; set; }
        public string ChipColor { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
