using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.OrderStatus.Commands.UpdateOrderStatusCommand
{
    public class UpdateOrderStatusResponse : BaseResponse
    {
        public UpdateOrderStatusResponse() : base()
        { }

        public UpdateOrderStatusResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateOrderStatusResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
