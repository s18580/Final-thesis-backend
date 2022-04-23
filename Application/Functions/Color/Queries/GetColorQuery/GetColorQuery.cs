using MediatR;

namespace Application.Functions.Color.Queries.GetColorQuery
{
    public class GetColorQuery : IRequest<Domain.Models.Color>
    {
        public int IdColor { get; set; }
    }
}
