using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Valuation.Queries.GetValuationListByWorkerQuery
{
    public class GetValuationListByWorkerResponse : BaseResponse
    {
        public List<Domain.Models.Valuation> valuations { get; }

        public GetValuationListByWorkerResponse(List<Domain.Models.Valuation> elements) : base()
        {
            valuations = elements;
        }

        public GetValuationListByWorkerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetValuationListByWorkerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
