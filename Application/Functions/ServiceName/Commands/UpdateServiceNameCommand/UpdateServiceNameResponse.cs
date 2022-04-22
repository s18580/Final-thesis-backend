using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.ServiceName.Commands.UpdateServiceNameCommand
{
    public class UpdateServiceNameResponse : BaseResponse
    {
        public UpdateServiceNameResponse() : base()
        { }

        public UpdateServiceNameResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateServiceNameResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
