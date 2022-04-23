using MediatR;

namespace Application.Functions.Paper.Queries.GetPaperQuery
{
    public class GetPaperQuery : IRequest<Domain.Models.Paper>
    {
        public int IdPaper { get; set; }
    }
}
