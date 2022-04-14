using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.DeliveryType.Commands.UpdateDeliveryTypeCommand
{
    public class UpdateDeliveryTypeResponse : BaseResponse
    {
        public UpdateDeliveryTypeResponse() : base()
        { }

        public UpdateDeliveryTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdateDeliveryTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
