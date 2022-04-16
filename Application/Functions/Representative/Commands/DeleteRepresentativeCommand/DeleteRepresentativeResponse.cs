using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Representative.Commands.DeleteRepresentativeCommand
{
    public class DeleteRepresentativeResponse : BaseResponse
    {
        public DeleteRepresentativeResponse() : base()
        { }

        public DeleteRepresentativeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteRepresentativeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
