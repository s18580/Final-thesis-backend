using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Customer.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerResponse : BaseResponse
    {
        public DeleteCustomerResponse() : base()
        { }

        public DeleteCustomerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteCustomerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
