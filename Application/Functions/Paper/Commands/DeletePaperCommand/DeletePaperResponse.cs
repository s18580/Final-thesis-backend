using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Paper.Commands.DeletePaperCommand
{
    public class DeletePaperResponse : BaseResponse
    {
        public DeletePaperResponse() : base()
        { }

        public DeletePaperResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeletePaperResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
