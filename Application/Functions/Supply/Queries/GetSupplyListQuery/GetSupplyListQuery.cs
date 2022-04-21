using MediatR;

namespace Application.Functions.Supply.Queries.GetSupplyListQuery
{
    public class GetSupplyListQuery : IRequest<List<Domain.Models.Supply>>
    {
    }
}
