using MediatR;

namespace Application.Functions.ValuationPriceList.Queries.GetValuationPriceListListByPriceListQuery
{
    public class GetValuationPriceListListByPriceListQuery : IRequest<GetValuationPriceListListByPriceListResponse>
    {
        public int IdPriceList { get; set; }
    }
}
