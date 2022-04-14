using MediatR;

namespace Application.Functions.FileStatus.Commands.DeleteFileStatusCommand
{
    public class DeleteFileStatusCommand : IRequest<DeleteFileStatusResponse>
    {
        public int IdFileStatus { get; set; }
    }
}
