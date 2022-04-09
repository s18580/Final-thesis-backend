using MediatR;

namespace Application.Functions.Workers.Commands.DeleteWorker
{
    public class DeleteWorkerCommand : IRequest<DeleteWorkerResponse>
    {
        public int Id { get; set; }
    }
}
