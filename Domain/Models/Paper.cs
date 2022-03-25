using Final_thesis_api.Enumerators;

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
        public int IdLink { get; set; }
        public bool IsForCover { get; set; }

        public OrderItem OrderItem { get; set; }
        public Valuation Valuation { get; set; }
    }
}
