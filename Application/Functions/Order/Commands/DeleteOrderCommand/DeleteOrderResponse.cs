using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Order.Commands.DeleteOrderCommand
{
    public class DeleteOrderResponse : BaseResponse
    {
        public DeleteOrderResponse() : base()
        { }

        public DeleteOrderResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteOrderResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
