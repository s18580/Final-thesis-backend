using MediatR;

namespace Application.Functions.ValuationPriceList.Queries.GetValuationPriceListQuery
{
    public class GetValuationPriceListQuery : IRequest<Domain.Models.ValuationPriceList>
    {
        public int IdValuation { get; set; }
        public int IdPriceList { get; set; }
    }
}
