using Domain.Models;
using MediatR;

namespace Application.Functions.Workers.Queries.GetWorker
{
    public class GetWorkerQuery : IRequest<WorkerDTO>
    {
        public int Id { get; set; }
    }
}
