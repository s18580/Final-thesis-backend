using MediatR;

namespace Application.Functions.Assignment.Commands.DeleteAssignmentCommand
{
    public class DeleteAssignmentCommand : IRequest<DeleteAssignmentResponse>
    {
        public int IdWorker { get; set; }
        public int IdOrder { get; set; }
    }
}
