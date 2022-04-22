using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Service.Commands.DeleteServiceCommand
{
    public class DeleteServiceResponse : BaseResponse
    {
        public DeleteServiceResponse() : base()
        { }

        public DeleteServiceResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteServiceResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
