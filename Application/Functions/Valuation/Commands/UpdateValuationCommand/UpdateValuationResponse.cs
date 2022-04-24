using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Valuation.Commands.UpdateValuationCommand
{
    public class UpdateValuationResponse : BaseResponse
    {
        public UpdateValuationResponse() : base()
        { }

        public UpdateValuationResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateValuationResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
