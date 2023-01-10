using Application.Functions.DTOs;
using MediatR;

namespace Application.Functions.Valuation.Commands.CreateValuationCommand
{
    public class CreateValuationCommand : IRequest<CreateValuationResponse>
    {
        public string Name { get; set; }
        public string Recipient { get; set; }
        public DateTime OfferValidityDate { get; set; }
        public int? InsideCirculation { get; set; }
        public int Capacity { get; set; }
        public string InsideFormat { get; set; }
        public string CoverFormat { get; set; }
        public string InsideSheetFormat { get; set; }
        public string CoverSheetFormat { get; set; }
        public int InsideSheetNumber { get; set; }
        public int? CoverSheetNumber { get; set; }
        public string InsideOther { get; set; }
        public string CoverOther { get; set; }
        public int? CoverCirculation { get; set; }
        public int InsidePlateNumber { get; set; }
        public int? CoverPlateNumber { get; set; }
        public int MainCirculation { get; set; }
        public double FinalPrice { get; set; }
        public int IdAuthor { get; set; }
        public int? IdOrderItem { get; set; }
        public int? IdBindingType { get; set; }
        public ICollection<ColorDTO> Colors { get; set; }
        public ICollection<PaperDTO> Papers { get; set; }
        public ICollection<ServiceDTO> Services { get; set; }
        public ICollection<ValuationPriceListDTO> ValuationPriceLists { get; set; }
    }
}
