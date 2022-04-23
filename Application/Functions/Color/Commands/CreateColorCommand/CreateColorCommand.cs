using MediatR;

namespace Application.Functions.Color.Commands.CreateColorCommand
{
    public class CreateColorCommand : IRequest<CreateColorResponse>
    {
        public string Name { get; set; }
        public int IdLink { get; set; }
        public bool IsForCover { get; set; }
    }
}
