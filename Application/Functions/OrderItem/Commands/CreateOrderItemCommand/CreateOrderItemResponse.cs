using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.OrderItem.Commands.CreateOrderItemCommand
{
    public class CreateOrderItemResponse : BaseResponse
    {
        public int Id { get; }

        public CreateOrderItemResponse(int id) : base()
        {
            Id = id;
        }

        public CreateOrderItemResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateOrderItemResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
