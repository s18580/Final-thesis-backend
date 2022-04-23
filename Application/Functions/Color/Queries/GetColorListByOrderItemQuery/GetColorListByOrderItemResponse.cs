using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Color.Queries.GetColorListByOrderItemQuery
{
    public class GetColorListByOrderItemResponse : BaseResponse
    {
        public List<Domain.Models.Color> colors { get; }

        public GetColorListByOrderItemResponse(List<Domain.Models.Color> elements) : base()
        {
            colors = elements;
        }

        public GetColorListByOrderItemResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetColorListByOrderItemResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
