using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Paper.Commands.UpdatePaperCommand
{
    public class UpdatePaperResponse : BaseResponse
    {
        public UpdatePaperResponse() : base()
        { }

        public UpdatePaperResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdatePaperResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
