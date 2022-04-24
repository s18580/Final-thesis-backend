using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.OrderItemType.Commands.CreateOrderItemTypeCommand
{
    public class CreateOrderItemTypeResponse : BaseResponse
    {
        public int Id { get; }

        public CreateOrderItemTypeResponse(int id) : base()
        {
            Id = id;
        }

        public CreateOrderItemTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateOrderItemTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
