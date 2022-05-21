using Domain.Enumerators;

namespace Domain.Models
{
    public class Paper
    {
        public int IdPaper { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public string SheetFormat { get; set; }
        public FiberDirection FiberDirection { get; set; }
        public int Opacity { get; set; }
        public double PricePerKilogram { get; set; }
        public int Quantity { get; set; }
        public int? IdValuation { get; set; }
        public int? IdOrderItem { get; set; }

        public OrderItem OrderItem { get; set; }
        public Valuation Valuation { get; set; }
    }
}
