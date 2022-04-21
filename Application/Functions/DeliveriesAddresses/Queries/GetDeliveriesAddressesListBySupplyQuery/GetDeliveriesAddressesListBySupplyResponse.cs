using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.DeliveriesAddresses.Queries.GetDeliveriesAddressesListBySupplyQuery
{
    public class GetDeliveriesAddressesListBySupplyResponse : BaseResponse
    {
        public List<Domain.Models.DeliveriesAddresses> deliveriesAddresses { get; }

        public GetDeliveriesAddressesListBySupplyResponse(List<Domain.Models.DeliveriesAddresses> elements) : base()
        {
            deliveriesAddresses = elements;
        }

        public GetDeliveriesAddressesListBySupplyResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetDeliveriesAddressesListBySupplyResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
