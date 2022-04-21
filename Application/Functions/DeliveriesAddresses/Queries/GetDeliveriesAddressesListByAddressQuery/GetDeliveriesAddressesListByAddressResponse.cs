using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListByAddressQuery
{
    public class GetDeliveriesAddressesListByAddressResponse : BaseResponse
    {
        public List<Domain.Models.DeliveriesAddresses> deliveriesAddresses { get; }

        public GetDeliveriesAddressesListByAddressResponse(List<Domain.Models.DeliveriesAddresses> elements) : base()
        {
            deliveriesAddresses = elements;
        }

        public GetDeliveriesAddressesListByAddressResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetDeliveriesAddressesListByAddressResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
