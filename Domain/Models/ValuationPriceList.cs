using Domain.Models.DictionaryModels;

namespace Domain.Models
{
    public class ValuationPriceList
    {
        public int IdValuation { get; set; }
        public int IdPriceList { get; set; }

        public Valuation Valuation { get; set; }
        public PriceList PriceList { get; set; }
    }
}
