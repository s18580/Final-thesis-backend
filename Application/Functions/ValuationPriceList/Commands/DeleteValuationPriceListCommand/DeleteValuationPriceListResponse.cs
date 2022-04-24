using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.ValuationPriceList.Commands.DeleteValuationPriceListCommand
{
    public class DeleteValuationPriceListResponse : BaseResponse
    {
        public DeleteValuationPriceListResponse() : base()
        { }

        public DeleteValuationPriceListResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeleteValuationPriceListResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
