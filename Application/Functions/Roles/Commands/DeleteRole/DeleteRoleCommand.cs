using MediatR;

namespace Application.Functions.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest<DeleteRoleResponse>
    {
        public int Id { get; set; }
    }
}
