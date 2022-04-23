using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Paper.Commands.CreatePaperCommand
{
    public class CreatePaperResponse : BaseResponse
    {
        public CreatePaperResponse() : base()
        { }

        public CreatePaperResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreatePaperResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
