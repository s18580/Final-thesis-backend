using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.OrderItem.Commands.DeleteOrderItemCommand
{
    public class DeleteOrderItemResponse : BaseResponse
    {
        public DeleteOrderItemResponse() : base()
        { }

        public DeleteOrderItemResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteOrderItemResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
