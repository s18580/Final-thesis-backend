using MediatR;

namespace Application.Functions.Service.Queries.GetServiceListByValuationQuery
{
    public class GetServiceListByValuationQuery : IRequest<GetServiceListByValuationResponse>
    {
        public int IdValuation { get; set; }
    }
}
