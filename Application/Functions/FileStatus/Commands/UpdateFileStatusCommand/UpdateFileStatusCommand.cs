using MediatR;

namespace Application.Functions.FileStatus.Commands.UpdateFileStatusCommand
{
    public class UpdateFileStatusCommand : IRequest<UpdateFileStatusResponse>
    {
        public int IdFileStatus { get; set; }
        public string Name { get; set; }
    }
}
