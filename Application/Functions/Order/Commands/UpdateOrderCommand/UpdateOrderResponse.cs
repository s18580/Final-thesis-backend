using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Order.Commands.UpdateOrderCommand
{
    public class UpdateOrderResponse : BaseResponse
    {
        public UpdateOrderResponse() : base()
        { }

        public UpdateOrderResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateOrderResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
