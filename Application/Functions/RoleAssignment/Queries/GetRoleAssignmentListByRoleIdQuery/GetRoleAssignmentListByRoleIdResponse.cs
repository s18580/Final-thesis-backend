using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.RoleAssignment.Queries.GetRoleAssignmentListByRoleIdQuery
{
    public class GetRoleAssignmentListByRoleIdResponse : BaseResponse
    {
        public List<Domain.Models.RoleAssignment> roleAssignments { get; }

        public GetRoleAssignmentListByRoleIdResponse(List<Domain.Models.RoleAssignment> elements) : base()
        {
            roleAssignments = elements;
        }

        public GetRoleAssignmentListByRoleIdResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetRoleAssignmentListByRoleIdResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
