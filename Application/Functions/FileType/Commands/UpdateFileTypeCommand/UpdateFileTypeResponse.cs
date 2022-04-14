using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.FileType.Commands.UpdateFileTypeCommand
{
    public class UpdateFileTypeResponse : BaseResponse
    {
        public UpdateFileTypeResponse() : base()
        { }

        public UpdateFileTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateFileTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
