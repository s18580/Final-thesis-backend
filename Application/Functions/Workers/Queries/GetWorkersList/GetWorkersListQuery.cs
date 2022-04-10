using Domain.Models;
using MediatR;

namespace Application.Functions.Workers.Queries.GetWorkersList
{
    public class GetWorkersListQuery :IRequest<List<WorkerDTO>>
    {
    }
}
