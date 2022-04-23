using MediatR;

namespace Application.Functions.PriceList.Queries.GetPriceListQuery
{
    public class GetPriceListQuery : IRequest<Domain.Models.DictionaryModels.PriceList>
    {
        public int IdPriceList { get; set; }
    }
}
