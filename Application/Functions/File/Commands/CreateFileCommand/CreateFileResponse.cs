using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.File.Commands.CreateFileCommand
{
    public class CreateFileResponse : BaseResponse
    {
        public CreateFileResponse() : base()
        { }

        public CreateFileResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateFileResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
