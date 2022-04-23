using MediatR;

namespace Application.Functions.File.Queries.GetFileQuery
{
    public class GetFileQuery : IRequest<Domain.Models.File>
    {
        public int IdFile { get; set; }
    }
}
