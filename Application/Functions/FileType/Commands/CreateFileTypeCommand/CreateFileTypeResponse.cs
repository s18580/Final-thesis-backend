using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.FileType.Commands.CreateFileTypeCommand
{
    public class CreateFileTypeResponse : BaseResponse
    {
        public int Id { get; }

        public CreateFileTypeResponse(int id) : base()
        {
            Id = id;
        }

        public CreateFileTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateFileTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
