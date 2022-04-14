using MediatR;

namespace Application.Functions.DeliveryType.Queries.GetDeliveryTypeListQuery
{
    public class GetDeliveryTypeListQuery : IRequest<List<Domain.Models.DictionaryModels.DeliveryType>>
    {
    }
}
