using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.OrderItemType.Commands.DeleteOrderItemTypeCommand
{
    public class DeleteOrderItemTypeResponse : BaseResponse
    {
        public DeleteOrderItemTypeResponse() : base()
        { }

        public DeleteOrderItemTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteOrderItemTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
