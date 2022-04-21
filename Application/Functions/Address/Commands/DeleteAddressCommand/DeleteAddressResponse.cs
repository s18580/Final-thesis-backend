using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Address.Commands.DeleteAddressCommand
{
    public class DeleteAddressResponse : BaseResponse
    {
        public DeleteAddressResponse() : base()
        { }

        public DeleteAddressResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteAddressResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
