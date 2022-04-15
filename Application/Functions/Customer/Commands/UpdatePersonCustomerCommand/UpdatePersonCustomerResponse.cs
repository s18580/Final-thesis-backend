using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Customer.Commands.UpdatePersonCustomerCommand
{
    public class UpdatePersonCustomerResponse : BaseResponse
    {
        public UpdatePersonCustomerResponse() : base()
        { }

        public UpdatePersonCustomerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdatePersonCustomerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
