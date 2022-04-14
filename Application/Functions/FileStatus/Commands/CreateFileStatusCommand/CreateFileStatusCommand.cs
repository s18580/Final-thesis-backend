using MediatR;

namespace Application.Functions.FileStatus.Commands.CreateFileStatusCommand
{
    public class CreateFileStatusCommand : IRequest<CreateFileStatusResponse>
    {
        public string Name { get; set; }
    }
}
