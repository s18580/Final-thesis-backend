using MediatR;

namespace Application.Functions.Valuation.Queries.GetValuationListWithoutOrderItemQuery
{
    public class GetValuationListWithoutOrderItemQuery : IRequest<List<Domain.Models.Valuation>>
    {
    }
}
