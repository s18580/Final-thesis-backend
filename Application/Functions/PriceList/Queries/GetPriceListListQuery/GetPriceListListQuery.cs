using MediatR;

namespace Application.Functions.PriceList.Queries.GetPriceListListQuery
{
    public class GetPriceListListQuery : IRequest<List<Domain.Models.DictionaryModels.PriceList>>
    {
    }
}
