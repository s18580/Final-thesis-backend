using MediatR;

namespace Application.Functions.Supply.Queries.GetSupplyQuery
{
    public class GetSupplyQuery : IRequest<Domain.Models.Supply>
    {
        public int IdSupply { get; set; }
    }
}
