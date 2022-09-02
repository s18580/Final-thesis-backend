using MediatR;

namespace Application.Functions.Paper.Commands.CreatePaperCommand
{
    public class CreatePaperCommand : IRequest<CreatePaperResponse>
    {
        public string Name { get; set; }
        public string Kind { get; set; }
        public string SheetFormat { get; set; }
        public int FiberDirection { get; set; }
        public int Opacity { get; set; }
        public bool IsForCover { get; set; }
        public double PricePerKilogram { get; set; }
        public int Quantity { get; set; }
        public int? IdValuation { get; set; }
        public int? IdOrderItem { get; set; }
    }
}
