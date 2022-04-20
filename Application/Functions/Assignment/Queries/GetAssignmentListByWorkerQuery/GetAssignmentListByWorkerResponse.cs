using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Assignment.Queries.GetAssignmentListByWorkerQuery
{
    public class GetAssignmentListByWorkerResponse : BaseResponse
    {
        public List<Domain.Models.Assignment> assignments { get; }

        public GetAssignmentListByWorkerResponse(List<Domain.Models.Assignment> elements) : base()
        {
            assignments = elements;
        }

        public GetAssignmentListByWorkerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetAssignmentListByWorkerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
