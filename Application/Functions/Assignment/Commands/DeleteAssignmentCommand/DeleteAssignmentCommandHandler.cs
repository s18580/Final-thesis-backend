using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Assignment.Commands.DeleteAssignmentCommand
{
    public class DeleteAssignmentCommandHandler : IRequestHandler<DeleteAssignmentCommand, DeleteAssignmentResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteAssignmentCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteAssignmentResponse> Handle(DeleteAssignmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteAssignmentValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteAssignmentResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var assignmentsDelete = await _context.Assignments
                                                  .Where(p => p.IdWorker == request.IdWorker)
                                                  .Where(p => p.IdOrder == request.IdOrder)
                                                  .SingleAsync();

            _context.Assignments.Remove(assignmentsDelete);
            await _context.SaveChangesAsync();

            return new DeleteAssignmentResponse();
        }
    }
}
