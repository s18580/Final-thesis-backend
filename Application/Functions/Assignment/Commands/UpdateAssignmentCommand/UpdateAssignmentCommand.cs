using MediatR;

namespace Application.Functions.Assignment.Commands.UpdateAssignmentCommand
{
    public class UpdateAssignmentCommand : IRequest<UpdateAssignmentResponse>
    {
        public int IdWorker { get; set; }
        public int IdOrder { get; set; }
        public bool OrderLeader { get; set; }
    }
}
