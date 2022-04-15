using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Customer.CompanyCustomer.Commands.CreateCompanyCustomerCommand
{
    public class CreateCompanyCustomerResponse : BaseResponse
    {
        public CreateCompanyCustomerResponse() : base()
        { }

        public CreateCompanyCustomerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateCompanyCustomerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
