using MediatR;

namespace Application.Functions.FileType.Commands.DeleteFileTypeCommand
{
    public class DeleteFileTypeCommand : IRequest<DeleteFileTypeResponse>
    {
        public int IdFileType { get; set; }
    }
}
