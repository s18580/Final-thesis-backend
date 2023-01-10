using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Customer.Commands.CreateCompanyCustomerWithDataCommand
{
    public class CreateCompanyCustomerWithDataResponse : BaseResponse
    {
        public int Id { get; set; }
        public CreateCompanyCustomerWithDataResponse(int id) : base()
        { Id = id; }

        public CreateCompanyCustomerWithDataResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateCompanyCustomerWithDataResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
