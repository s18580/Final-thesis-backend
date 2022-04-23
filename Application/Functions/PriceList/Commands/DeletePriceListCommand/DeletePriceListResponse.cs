using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.PriceList.Commands.DeletePriceListCommand
{
    public class DeletePriceListResponse : BaseResponse
    {
        public DeletePriceListResponse() : base()
        { }

        public DeletePriceListResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public DeletePriceListResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
