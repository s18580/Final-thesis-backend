using MediatR;

namespace Application.Functions.Address.Queries.GetAddressQuery
{
    public class GetAddressQuery : IRequest<Domain.Models.Address>
    {
        public int IdAddress { get; set; }
    }
}
