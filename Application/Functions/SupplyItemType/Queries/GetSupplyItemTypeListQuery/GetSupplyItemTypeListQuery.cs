using MediatR;

namespace Application.Functions.SupplyItemType.Queries.GetSupplyItemTypeListQuery
{
    public class GetSupplyItemTypeListQuery : IRequest<List<Domain.Models.DictionaryModels.SupplyItemType>>
    {
    }
}
