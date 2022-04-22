using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.ServiceName.Commands.CreateServiceNameCommand
{
    public class CreateServiceNameResponse : BaseResponse
    {
        public CreateServiceNameResponse() : base()
        { }

        public CreateServiceNameResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateServiceNameResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
