using MediatR;

namespace Application.Functions.File.Commands.CreateFileCommand
{
    public class CreateFileCommand : IRequest<CreateFileResponse>
    {
        public string Name { get; set; }
        public int IdFileType { get; set; }
        public int? IdFileStatus { get; set; }
        public int? IdValuation { get; set; }
        public int? IdOrderItem { get; set; }
        public int? IdOrder { get; set; }
    }
}
