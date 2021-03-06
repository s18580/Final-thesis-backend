using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.DeliveriesAddresses.Commands.CreateDeliveriesAddressesCommand
{
    public class CreateDeliveriesAddressesResponse : BaseResponse
    {
        public int IdDeliveriesAddresses { get; }

        public CreateDeliveriesAddressesResponse(int id) : base()
        {
            IdDeliveriesAddresses = id;
        }

        public CreateDeliveriesAddressesResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateDeliveriesAddressesResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
