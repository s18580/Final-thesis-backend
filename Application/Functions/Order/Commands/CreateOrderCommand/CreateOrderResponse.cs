using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Order.Commands.CreateOrderCommand
{
    public class CreateOrderResponse : BaseResponse
    {
        public CreateOrderResponse() : base()
        { }

        public CreateOrderResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateOrderResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
