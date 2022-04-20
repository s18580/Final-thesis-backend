using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Assignment.Queries.GetAssignmentListByOrderQuery
{
    public class GetAssignmentListByOrderResponse : BaseResponse
    {
        public List<Domain.Models.Assignment> assignments { get; }

        public GetAssignmentListByOrderResponse(List<Domain.Models.Assignment> elements) : base()
        {
            assignments = elements;
        }

        public GetAssignmentListByOrderResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetAssignmentListByOrderResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
