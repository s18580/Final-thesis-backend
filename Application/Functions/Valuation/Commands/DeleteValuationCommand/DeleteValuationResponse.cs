using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Valuation.Commands.DeleteValuationCommand
{
    public class DeleteValuationResponse : BaseResponse
    {
        public DeleteValuationResponse() : base()
        { }

        public DeleteValuationResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteValuationResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
