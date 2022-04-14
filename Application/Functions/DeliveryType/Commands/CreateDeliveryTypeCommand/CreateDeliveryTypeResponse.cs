using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.DeliveryType.Commands.CreateDeliveryTypeCommand
{
    public class CreateDeliveryTypeResponse : BaseResponse
    {
        public CreateDeliveryTypeResponse() : base()
        { }

        public CreateDeliveryTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateDeliveryTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
