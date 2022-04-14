using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.FileStatus.Commands.UpdateFileStatusCommand
{
    public class UpdateFileStatusResponse : BaseResponse
    {
        public UpdateFileStatusResponse() : base()
        { }

        public UpdateFileStatusResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateFileStatusResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
