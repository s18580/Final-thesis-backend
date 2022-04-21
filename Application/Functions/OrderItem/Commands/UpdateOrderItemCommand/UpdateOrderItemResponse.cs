using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.OrderItem.Commands.UpdateOrderItemCommand
{
    public class UpdateOrderItemResponse : BaseResponse
    {
        public UpdateOrderItemResponse() : base()
        { }

        public UpdateOrderItemResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateOrderItemResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
