using MediatR;

namespace Application.Functions.FileType.Commands.CreateFileTypeCommand
{
    public class CreateFileTypeCommand : IRequest<CreateFileTypeResponse>
    {
        public string Name { get; set; }
    }
}
