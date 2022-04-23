using MediatR;

namespace Application.Functions.Color.Commands.UpdateColorCommand
{
    public class UpdateColorCommand : IRequest<UpdateColorResponse>
    {
        public int IdColor { get; set; }
        public string Name { get; set; }
        public bool IsForCover { get; set; }
    }
}
