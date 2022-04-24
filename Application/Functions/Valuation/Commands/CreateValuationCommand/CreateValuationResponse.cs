using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Valuation.Commands.CreateValuationCommand
{
    public class CreateValuationResponse : BaseResponse
    {
        public int Id { get; }

        public CreateValuationResponse(int id) : base()
        {
            Id = id;
        }

        public CreateValuationResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateValuationResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
