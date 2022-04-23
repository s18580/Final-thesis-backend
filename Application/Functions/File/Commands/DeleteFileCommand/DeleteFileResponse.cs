using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.File.Commands.DeleteFileCommand
{
    public class DeleteFileResponse : BaseResponse
    {
        public DeleteFileResponse() : base()
        { }

        public DeleteFileResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteFileResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
