using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.ValuationPriceList.Commands.CreateValuationPriceListCommand
{
    public class CreateValuationPriceListResponse : BaseResponse
    {
        public int IdValuation { get; }
        public int IdPriceList { get; }

        public CreateValuationPriceListResponse(int idValuation, int idPriceList) : base()
        {
            IdValuation = idValuation;
            IdPriceList = idPriceList;
        }

        public CreateValuationPriceListResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateValuationPriceListResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
