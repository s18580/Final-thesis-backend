using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Customer.Commands.UpdateCompanyCustomerCommand
{
    public class UpdateCompanyCustomerResponse : BaseResponse
    {
        public UpdateCompanyCustomerResponse() : base()
        { }

        public UpdateCompanyCustomerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateCompanyCustomerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
