using MediatR;

namespace Application.Functions.SupplyItemType.Queries.GetSupplyItemTypeQuery
{
    public class GetSupplyItemTypeQuery : IRequest<Domain.Models.DictionaryModels.SupplyItemType>
    {
        public int IdSupplyItemType { get; set; }
    }
}
