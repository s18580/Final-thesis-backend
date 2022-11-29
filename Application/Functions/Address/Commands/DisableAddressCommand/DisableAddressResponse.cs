using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Address.Commands.DisableAddressCommand
{
    public class DisableAddressResponse : BaseResponse
    {
        public DisableAddressResponse() : base()
        { }

        public DisableAddressResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DisableAddressResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
