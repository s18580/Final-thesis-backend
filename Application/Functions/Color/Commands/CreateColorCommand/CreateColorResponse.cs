using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Color.Commands.CreateColorCommand
{
    public class CreateColorResponse : BaseResponse
    {
        public int Id { get; }

        public CreateColorResponse(int id) : base()
        {
            Id = id;
        }

        public CreateColorResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateColorResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
