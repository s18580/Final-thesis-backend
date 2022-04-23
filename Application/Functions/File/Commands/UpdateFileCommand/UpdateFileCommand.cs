using MediatR;

namespace Application.Functions.File.Commands.UpdateFileCommand
{
    public class UpdateFileCommand : IRequest<UpdateFileResponse>
    {
        public int IdFile { get; set; }
        public string Name { get; set; }
        public int IdFileType { get; set; }
        public int? IdFileStatus { get; set; }
    }
}
