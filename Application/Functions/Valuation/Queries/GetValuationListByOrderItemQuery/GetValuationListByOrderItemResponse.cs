using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Valuation.Queries.GetValuationListByOrderItemQuery
{
    public class GetValuationListByOrderItemResponse : BaseResponse
    {
        public List<Domain.Models.Valuation> valuations { get; }

        public GetValuationListByOrderItemResponse(List<Domain.Models.Valuation> elements) : base()
        {
            valuations = elements;
        }

        public GetValuationListByOrderItemResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetValuationListByOrderItemResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
