using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.FileStatus.Commands.CreateFileStatusCommand
{
    public class CreateFileStatusResponse : BaseResponse
    {
        public int Id { get; }

        public CreateFileStatusResponse(int id) : base()
        {
            Id = id;
        }

        public CreateFileStatusResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateFileStatusResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
