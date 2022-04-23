using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.PriceList.Commands.CreatePriceListCommand
{
    public class CreatePriceListResponse : BaseResponse
    {
        public CreatePriceListResponse() : base()
        { }

        public CreatePriceListResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreatePriceListResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
