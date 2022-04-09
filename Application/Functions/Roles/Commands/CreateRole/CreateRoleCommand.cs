using MediatR;

namespace Application.Functions.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<CreateRoleResponse>
    {
        public string Name { get; set; }
    }
}
