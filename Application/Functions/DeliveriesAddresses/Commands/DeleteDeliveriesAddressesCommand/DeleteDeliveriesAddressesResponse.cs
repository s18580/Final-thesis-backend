using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.DeliveriesAddresses.Commands.DeleteDeliveriesAddressesCommand
{
    public class DeleteDeliveriesAddressesResponse : BaseResponse
    {
        public DeleteDeliveriesAddressesResponse() : base()
        { }

        public DeleteDeliveriesAddressesResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteDeliveriesAddressesResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
