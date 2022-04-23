using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Color.Commands.UpdateColorCommand
{
    public class UpdateColorResponse : BaseResponse
    {
        public UpdateColorResponse() : base()
        { }

        public UpdateColorResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateColorResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
