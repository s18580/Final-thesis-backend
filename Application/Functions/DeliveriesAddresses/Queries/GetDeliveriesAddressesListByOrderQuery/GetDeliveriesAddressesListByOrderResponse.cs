using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListByOrderQuery
{
    public class GetDeliveriesAddressesListByOrderResponse : BaseResponse
    {
        public List<Domain.Models.DeliveriesAddresses> deliveriesAddresses { get; }

        public GetDeliveriesAddressesListByOrderResponse(List<Domain.Models.DeliveriesAddresses> elements) : base()
        {
            deliveriesAddresses = elements;
        }

        public GetDeliveriesAddressesListByOrderResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetDeliveriesAddressesListByOrderResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
