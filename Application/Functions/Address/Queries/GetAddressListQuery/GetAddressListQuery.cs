using MediatR;

namespace Application.Functions.Address.Queries.GetAddressListQuery
{
    public class GetAddressListQuery : IRequest<List<Domain.Models.Address>>
    {
    }
}
