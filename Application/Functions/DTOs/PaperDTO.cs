namespace Application.Functions.DTOs
{
    public class PaperDTO
    {
        public string Name { get; set; }
        public string Kind { get; set; }
        public string SheetFormat { get; set; }
        public int FiberDirection { get; set; }
        public int Opacity { get; set; }
        public double PricePerKilogram { get; set; }
        public int Quantity { get; set; }
    }
}
