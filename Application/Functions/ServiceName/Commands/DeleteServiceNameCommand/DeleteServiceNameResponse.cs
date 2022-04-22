using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.ServiceName.Commands.DeleteServiceNameCommand
{
    public class DeleteServiceNameResponse : BaseResponse
    {
        public DeleteServiceNameResponse() : base()
        { }

        public DeleteServiceNameResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteServiceNameResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
