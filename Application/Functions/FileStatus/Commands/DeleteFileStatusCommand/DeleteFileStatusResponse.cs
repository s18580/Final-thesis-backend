using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.FileStatus.Commands.DeleteFileStatusCommand
{
    public class DeleteFileStatusResponse : BaseResponse
    {
        public DeleteFileStatusResponse() : base()
        { }

        public DeleteFileStatusResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteFileStatusResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
