using MediatR;

namespace Application.Functions.Supply.Queries.GetSupplyListByRepresetnativeQuery
{
    public class GetSupplyListByRepresetnativeQuery : IRequest<List<Domain.Models.Supply>>
    {
        public int Id { get; set; }
    }
}
