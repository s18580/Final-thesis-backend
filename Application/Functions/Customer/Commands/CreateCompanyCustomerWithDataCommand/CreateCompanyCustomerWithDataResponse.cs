using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Customer.Commands.CreateCompanyCustomerWithDataCommand
{
    public class CreateCompanyCustomerWithDataResponse : BaseResponse
    {
        public CreateCompanyCustomerWithDataResponse() : base()
        { }

        public CreateCompanyCustomerWithDataResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateCompanyCustomerWithDataResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
