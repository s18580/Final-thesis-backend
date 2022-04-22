using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Service.Commands.UpdateServiceCommand
{
    public class UpdateServiceResponse : BaseResponse
    {
        public UpdateServiceResponse() : base()
        { }

        public UpdateServiceResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateServiceResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
