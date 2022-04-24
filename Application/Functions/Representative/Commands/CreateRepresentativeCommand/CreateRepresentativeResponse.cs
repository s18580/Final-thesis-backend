using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Representative.Commands.CreateRepresentativeCommand
{
    public class CreateRepresentativeResponse : BaseResponse
    {
        public int Id { get; }

        public CreateRepresentativeResponse(int id) : base()
        {
            Id = id;
        }

        public CreateRepresentativeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateRepresentativeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
