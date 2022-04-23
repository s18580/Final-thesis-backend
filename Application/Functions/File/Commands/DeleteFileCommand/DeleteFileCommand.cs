using MediatR;

namespace Application.Functions.File.Commands.DeleteFileCommand
{
    public class DeleteFileCommand : IRequest<DeleteFileResponse>
    {
        public int IdFile { get; set; }
    }
}
