namespace Domain.Models
{
    public class Color
    {
        public int IdColor { get; set; }
        public string Name { get; set; }
        public bool IsForCover { get; set; }
        public int? IdValuation { get; set; }
        public int? IdOrderItem { get; set; }

        public OrderItem OrderItem { get; set; }
        public Valuation Valuation { get; set; }
    }
}
