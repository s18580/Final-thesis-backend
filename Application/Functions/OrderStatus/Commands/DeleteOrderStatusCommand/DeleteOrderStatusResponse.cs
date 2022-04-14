using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.OrderStatus.Commands.DeleteOrderStatusCommand
{
    public class DeleteOrderStatusResponse : BaseResponse
    {
        public DeleteOrderStatusResponse() : base()
        { }

        public DeleteOrderStatusResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteOrderStatusResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
