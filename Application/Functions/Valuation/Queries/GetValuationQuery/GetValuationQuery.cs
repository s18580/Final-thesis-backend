using MediatR;

namespace Application.Functions.Valuation.Queries.GetValuationQuery
{
    public class GetValuationQuery : IRequest<Domain.Models.Valuation>
    {
        public int IdValuation { get; set; }
    }
}
