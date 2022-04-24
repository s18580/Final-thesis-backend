using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.DeliveriesAddresses.Commands.CreateDeliveriesAddressesCommand
{
    public class CreateDeliveriesAddressesResponse : BaseResponse
    {
        public int IdAddress { get; }
        public int IdLink { get; }

        public CreateDeliveriesAddressesResponse(int idAddress, int idLink) : base()
        {
            IdAddress = idAddress;
            IdLink = idLink;
        }

        public CreateDeliveriesAddressesResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateDeliveriesAddressesResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
