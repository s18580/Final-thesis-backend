using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Customer.PersonCustomer.Commands.CreatePersonCustomerCommand
{
    public class CreatePersonCustomerResponse : BaseResponse
    {
        public CreatePersonCustomerResponse() : base()
        { }

        public CreatePersonCustomerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreatePersonCustomerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
