using MediatR;

namespace Application.Functions.Color.Commands.DeleteColorCommand
{
    public class DeleteColorCommand : IRequest<DeleteColorResponse>
    {
        public int IdColor { get; set; }
    }
}
