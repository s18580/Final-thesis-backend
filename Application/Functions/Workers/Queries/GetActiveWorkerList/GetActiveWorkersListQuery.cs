using MediatR;

namespace Application.Functions.Workers.Queries.GetActiveWorkerList
{
    public class GetActiveWorkersListQuery : IRequest<List<WorkerDTO>>
    {
    }
}
