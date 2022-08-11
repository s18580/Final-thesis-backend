using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Order.Commands.CreateOrderWithDataCommand
{
    public class CreateOrderWithDataResponse : BaseResponse
    {
        public CreateOrderWithDataResponse() : base()
        { }

        public CreateOrderWithDataResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateOrderWithDataResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
