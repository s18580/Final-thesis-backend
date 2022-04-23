using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Color.Queries.GetColorListByValuationQuery
{
    public class GetColorListByValuationResponse : BaseResponse
    {
        public List<Domain.Models.Color> colors { get; }

        public GetColorListByValuationResponse(List<Domain.Models.Color> elements) : base()
        {
            colors = elements;
        }

        public GetColorListByValuationResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetColorListByValuationResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
