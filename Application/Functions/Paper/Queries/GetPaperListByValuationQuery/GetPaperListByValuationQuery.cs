using MediatR;

namespace Application.Functions.Paper.Queries.GetPaperListByValuationQuery
{
    public class GetPaperListByValuationQuery : IRequest<GetPaperListByValuationResponse>
    {
        public int IdValuation { get; set; }
    }
}
