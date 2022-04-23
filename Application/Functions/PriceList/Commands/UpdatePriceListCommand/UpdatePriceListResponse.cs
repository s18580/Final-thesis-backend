using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.PriceList.Commands.UpdatePriceListCommand
{
    public class UpdatePriceListResponse : BaseResponse
    {
        public UpdatePriceListResponse() : base()
        { }

        public UpdatePriceListResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public UpdatePriceListResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
