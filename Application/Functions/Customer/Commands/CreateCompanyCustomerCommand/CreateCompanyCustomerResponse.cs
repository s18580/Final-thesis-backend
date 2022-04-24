using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Customer.Commands.CreateCompanyCustomerCommand
{
    public class CreateCompanyCustomerResponse : BaseResponse
    {
        public int Id { get; }

        public CreateCompanyCustomerResponse(int id) : base()
        {
            Id = id;
        }

        public CreateCompanyCustomerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateCompanyCustomerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
