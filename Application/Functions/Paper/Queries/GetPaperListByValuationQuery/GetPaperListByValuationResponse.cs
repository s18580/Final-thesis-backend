using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Paper.Queries.GetPaperListByValuationQuery
{
    public class GetPaperListByValuationResponse : BaseResponse
    {
        public List<Domain.Models.Paper> papers { get; }

        public GetPaperListByValuationResponse(List<Domain.Models.Paper> elements) : base()
        {
            papers = elements;
        }

        public GetPaperListByValuationResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetPaperListByValuationResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
