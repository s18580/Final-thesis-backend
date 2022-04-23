using MediatR;

namespace Application.Functions.Color.Queries.GetColorListByValuationQuery
{
    public class GetColorListByValuationQuery : IRequest<GetColorListByValuationResponse>
    {
        public int IdValuation { get; set; }
    }
}
