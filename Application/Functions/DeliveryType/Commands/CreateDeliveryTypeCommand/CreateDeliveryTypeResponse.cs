using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.DeliveryType.Commands.CreateDeliveryTypeCommand
{
    public class CreateDeliveryTypeResponse : BaseResponse
    {
        public int Id { get; }

        public CreateDeliveryTypeResponse(int id) : base()
        {
            Id = id;
        }

        public CreateDeliveryTypeResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateDeliveryTypeResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
