using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.OrderItemType.Commands.UpdateOrderItemTypeCommand
{
    public class UpdateOrderItemTypeResponse : BaseResponse
    {
        public UpdateOrderItemTypeResponse() : base()
        { }

        public UpdateOrderItemTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateOrderItemTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
