namespace Application.Functions.OrderItem
{
    public class GetPaperDTO
    {
        public int IdPaper { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public string SheetFormat { get; set; }
        public string FiberDirection { get; set; }
        public int Opacity { get; set; }
        public bool IsForCover { get; set; }
        public double PricePerKilogram { get; set; }
        public int Quantity { get; set; }
        public int? IdValuation { get; set; }
        public int? IdOrderItem { get; set; }
    }
}
