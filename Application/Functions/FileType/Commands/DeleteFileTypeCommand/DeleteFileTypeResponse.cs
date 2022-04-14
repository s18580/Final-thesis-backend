using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.FileType.Commands.DeleteFileTypeCommand
{
    public class DeleteFileTypeResponse : BaseResponse
    {
        public DeleteFileTypeResponse() : base()
        { }

        public DeleteFileTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteFileTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
