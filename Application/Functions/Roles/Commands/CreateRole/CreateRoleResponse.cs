using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Roles.Commands.CreateRole
{
    public class CreateRoleResponse : BaseResponse
    {
        public int Id { get; }

        public CreateRoleResponse(int id) : base()
        {
            Id = id;
        }

        public CreateRoleResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public CreateRoleResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
