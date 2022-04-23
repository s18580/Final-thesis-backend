using MediatR;

namespace Application.Functions.File.Commands.CreateFileCommand
{
    public class CreateFileCommand : IRequest<CreateFileResponse>
    {
        public string Name { get; set; }
        public int IdFileType { get; set; }
        public int? IdFileStatus { get; set; }
        public int IdLink { get; set; }
    }
}
