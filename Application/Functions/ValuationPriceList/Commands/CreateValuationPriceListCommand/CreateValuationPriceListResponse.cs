using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.ValuationPriceList.Commands.CreateValuationPriceListCommand
{
    public class CreateValuationPriceListResponse : BaseResponse
    {
        public CreateValuationPriceListResponse() : base()
        { }

        public CreateValuationPriceListResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateValuationPriceListResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
