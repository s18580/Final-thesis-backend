using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.FileStatus.Commands.CreateFileStatusCommand
{
    public class CreateFileStatusResponse : BaseResponse
    {
        public CreateFileStatusResponse() : base()
        { }

        public CreateFileStatusResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateFileStatusResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
