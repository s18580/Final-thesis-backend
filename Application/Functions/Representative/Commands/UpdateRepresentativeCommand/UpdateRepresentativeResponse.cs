using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Representative.Commands.UpdateRepresentativeCommand
{
    public class UpdateRepresentativeResponse : BaseResponse
    {
        public UpdateRepresentativeResponse() : base()
        { }

        public UpdateRepresentativeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateRepresentativeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
