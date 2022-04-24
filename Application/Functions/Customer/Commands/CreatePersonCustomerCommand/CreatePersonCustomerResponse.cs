using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Customer.Commands.CreatePersonCustomerCommand
{
    public class CreatePersonCustomerResponse : BaseResponse
    {
        public int Id { get; }

        public CreatePersonCustomerResponse(int id) : base()
        {
            Id = id;
        }

        public CreatePersonCustomerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreatePersonCustomerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
