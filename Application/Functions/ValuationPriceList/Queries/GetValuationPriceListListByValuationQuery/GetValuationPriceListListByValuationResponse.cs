using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.ValuationPriceList.Queries.GetValuationPriceListListByValuationQuery
{
    public class GetValuationPriceListListByValuationResponse : BaseResponse
    {
        public List<Domain.Models.ValuationPriceList> valuationPriceLists { get; }

        public GetValuationPriceListListByValuationResponse(List<Domain.Models.ValuationPriceList> elements) : base()
        {
            valuationPriceLists = elements;
        }

        public GetValuationPriceListListByValuationResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetValuationPriceListListByValuationResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
