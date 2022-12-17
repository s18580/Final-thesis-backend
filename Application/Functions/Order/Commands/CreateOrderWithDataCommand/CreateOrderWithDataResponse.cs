using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Order.Commands.CreateOrderWithDataCommand
{
    public class CreateOrderWithDataResponse : BaseResponse
    {
        public int Id { get; set; }
        public CreateOrderWithDataResponse(int id) : base()
        { Id = id; }

        public CreateOrderWithDataResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateOrderWithDataResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
