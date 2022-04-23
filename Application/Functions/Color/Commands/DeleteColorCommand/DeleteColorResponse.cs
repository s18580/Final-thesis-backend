using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Color.Commands.DeleteColorCommand
{
    public class DeleteColorResponse : BaseResponse
    {
        public DeleteColorResponse() : base()
        { }

        public DeleteColorResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteColorResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
