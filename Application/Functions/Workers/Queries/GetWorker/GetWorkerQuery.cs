using Domain.Models;
using MediatR;

namespace Application.Functions.Workers.Queries.GetWorker
{
    public class GetWorkerQuery : IRequest<Worker>
    {
        public int Id { get; set; }
    }
}
