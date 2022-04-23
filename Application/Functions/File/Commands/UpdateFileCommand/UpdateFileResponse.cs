using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.File.Commands.UpdateFileCommand
{
    public class UpdateFileResponse : BaseResponse
    {
        public UpdateFileResponse() : base()
        { }

        public UpdateFileResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateFileResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
