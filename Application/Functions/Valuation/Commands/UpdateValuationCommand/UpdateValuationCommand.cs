using MediatR;

namespace Application.Functions.Valuation.Commands.UpdateValuationCommand
{
    public class UpdateValuationCommand : IRequest<UpdateValuationResponse>
    {
        public int IdValuation { get; set; }
        public string Name { get; set; }
        public DateTime? OfferValidityDate { get; set; }
        public double GraphicDesignPrice { get; set; }
        public double SamplePrintoutsPrice { get; set; }
        public bool PrintingOnReverse { get; set; }
        public double UnitPriceNet { get; set; }
        public int Circulation { get; set; }
        public int? Capacity { get; set; }
        public string InsideFormat { get; set; }
        public string CoverFormat { get; set; }
        public string InsideSheetFormat { get; set; }
        public string CoverSheetFormat { get; set; }
        public int PrintingPlateNuber { get; set; }
        public double PrintPrice { get; set; }
        public int? IdBindingType { get; set; }
    }
}
