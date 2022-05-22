using Domain.Enumerators;
using MediatR;

namespace Application.Functions.Paper.Commands.UpdatePaperCommand
{
    public class UpdatePaperCommand : IRequest<UpdatePaperResponse>
    {
        public int IdPaper { get; set; }
        public string Name { get; set; }
        public string Kind { get; set; }
        public string SheetFormat { get; set; }
        public int FiberDirection { get; set; }
        public int Opacity { get; set; }
        public double PricePerKilogram { get; set; }
        public int Quantity { get; set; }
    }
}
