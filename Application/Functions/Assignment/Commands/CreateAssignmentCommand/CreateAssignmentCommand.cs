using MediatR;

namespace Application.Functions.Assignment.Commands.CreateAssignmentCommand
{
    public class CreateAssignmentCommand : IRequest<CreateAssignmentResponse>
    {
        public int IdWorker { get; set; }
        public int IdOrder { get; set; }
        public bool OrderLeader { get; set; }
    }
}
