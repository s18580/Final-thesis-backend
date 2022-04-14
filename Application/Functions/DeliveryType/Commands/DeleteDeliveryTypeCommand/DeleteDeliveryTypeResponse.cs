using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.DeliveryType.Commands.DeleteDeliveryTypeCommand
{
    public class DeleteDeliveryTypeResponse : BaseResponse
    {
        public DeleteDeliveryTypeResponse() : base()
        { }

        public DeleteDeliveryTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteDeliveryTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
