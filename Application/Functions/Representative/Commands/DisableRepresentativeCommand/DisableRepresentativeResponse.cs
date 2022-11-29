using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Representative.Commands.DisableRepresentativeCommand
{
    public class DisableRepresentativeResponse : BaseResponse
    {
        public DisableRepresentativeResponse() : base()
        { }

        public DisableRepresentativeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DisableRepresentativeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
