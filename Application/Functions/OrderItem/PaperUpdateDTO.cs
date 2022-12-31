using Domain.Enumerators;

namespace Application.Functions.OrderItem
{
    public class PaperUpdateDTO
    {
        public int IdPaper { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public string SheetFormat { get; set; }
        public int FiberDirection { get; set; }
        public int Opacity { get; set; }
        public bool IsForCover { get; set; }
        public double PricePerKilogram { get; set; }
        public int Quantity { get; set; }
    }
}
