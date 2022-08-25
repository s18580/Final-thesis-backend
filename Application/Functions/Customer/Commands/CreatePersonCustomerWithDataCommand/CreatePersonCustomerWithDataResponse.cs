using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Customer.Commands.CreatePersonCustomerWithDataCommand
{
    public class CreatePersonCustomerWithDataResponse : BaseResponse
    {
        public CreatePersonCustomerWithDataResponse() : base()
        { }

        public CreatePersonCustomerWithDataResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreatePersonCustomerWithDataResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
