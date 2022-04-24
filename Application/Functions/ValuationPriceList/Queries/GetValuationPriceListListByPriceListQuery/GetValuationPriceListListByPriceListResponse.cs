using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.ValuationPriceList.Queries.GetValuationPriceListListByPriceListQuery
{
    public class GetValuationPriceListListByPriceListResponse : BaseResponse
    {
        public List<Domain.Models.ValuationPriceList> valuationPriceLists { get; }

        public GetValuationPriceListListByPriceListResponse(List<Domain.Models.ValuationPriceList> elements) : base()
        {
            valuationPriceLists = elements;
        }

        public GetValuationPriceListListByPriceListResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetValuationPriceListListByPriceListResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
