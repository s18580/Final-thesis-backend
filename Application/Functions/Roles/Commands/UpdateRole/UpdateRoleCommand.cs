using MediatR;

namespace Application.Functions.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest<UpdateRoleResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
