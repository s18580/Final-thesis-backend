using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.OrderStatus.Commands.CreateOrderStatusCommand
{
    public class CreateOrderStatusResponse : BaseResponse
    {
        public CreateOrderStatusResponse() : base()
        { }

        public CreateOrderStatusResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateOrderStatusResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
