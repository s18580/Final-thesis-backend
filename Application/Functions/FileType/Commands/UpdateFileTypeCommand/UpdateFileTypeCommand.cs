using MediatR;

namespace Application.Functions.FileType.Commands.UpdateFileTypeCommand
{
    public class UpdateFileTypeCommand : IRequest<UpdateFileTypeResponse>
    {
        public int IdFileType { get; set; }
        public string Name { get; set; }
    }
}
