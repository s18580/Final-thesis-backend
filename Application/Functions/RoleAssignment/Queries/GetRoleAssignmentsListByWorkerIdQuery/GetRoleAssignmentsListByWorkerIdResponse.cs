using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.RoleAssignment.Queries.GetRoleAssignmentsListByWorkerIdQuery
{
    public class GetRoleAssignmentsListByWorkerIdResponse : BaseResponse
    {
        public List<Domain.Models.RoleAssignment> roleAssignments { get; }

        public GetRoleAssignmentsListByWorkerIdResponse(List<Domain.Models.RoleAssignment> elements) : base()
        {
            roleAssignments = elements;
        }

        public GetRoleAssignmentsListByWorkerIdResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetRoleAssignmentsListByWorkerIdResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
