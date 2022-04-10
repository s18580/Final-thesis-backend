using MediatR;

namespace Application.Functions.Workers.Commands.DisableWorker
{
    public class DisableWorkerCommand : IRequest<DisableWorkerResponse>
    {
        public int Id { get; set; }
        public bool IsDisabled { get; set; }
    }
}
