using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Valuation.Commands.CreateValuationCommand
{
    public class CreateValuationResponse : BaseResponse
    {
        public CreateValuationResponse() : base()
        { }

        public CreateValuationResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateValuationResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
