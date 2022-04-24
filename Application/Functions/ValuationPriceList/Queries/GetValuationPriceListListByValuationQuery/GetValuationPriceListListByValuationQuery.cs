using MediatR;

namespace Application.Functions.ValuationPriceList.Queries.GetValuationPriceListListByValuationQuery
{
    public class GetValuationPriceListListByValuationQuery : IRequest<GetValuationPriceListListByValuationResponse>
    {
        public int IdValuation { get; set; }
    }
}
