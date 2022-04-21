using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Address.Commands.UpdateAddressCommand
{
    public class UpdateAddressResponse : BaseResponse
    {
        public UpdateAddressResponse() : base()
        { }

        public UpdateAddressResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateAddressResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
