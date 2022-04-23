using MediatR;

namespace Application.Functions.Paper.Commands.DeletePaperCommand
{
    public class DeletePaperCommand : IRequest<DeletePaperResponse>
    {
        public int IdPaper { get; set; }
    }
}
