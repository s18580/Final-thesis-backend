using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Paper.Queries.GetPaperListByOrderItemQuery
{
    public class GetPaperListByOrderItemResponse : BaseResponse
    {
        public List<Domain.Models.Paper> papers { get; }

        public GetPaperListByOrderItemResponse(List<Domain.Models.Paper> elements) : base()
        {
            papers = elements;
        }

        public GetPaperListByOrderItemResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetPaperListByOrderItemResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
