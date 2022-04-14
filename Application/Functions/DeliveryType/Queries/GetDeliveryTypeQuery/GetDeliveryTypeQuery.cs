using MediatR;

namespace Application.Functions.DeliveryType.Queries.GetDeliveryTypeQuery
{
    public class GetDeliveryTypeQuery : IRequest<Domain.Models.DictionaryModels.DeliveryType>
    {
        public int IdDeliveryType { get; set; }
    }
}
