using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Assignment.Commands.UpdateAssignmentCommand
{
    public class UpdateAssignmentCommandHandler : IRequestHandler<UpdateAssignmentCommand, UpdateAssignmentResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateAssignmentCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateAssignmentResponse> Handle(UpdateAssignmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateAssignmentValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateAssignmentResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedAssignment = await _context.Assignments
                                                   .Where(p => p.IdWorker == request.IdWorker)
                                                   .Where(p => p.IdOrder == request.IdOrder)
                                                   .SingleAsync();

            if (selectedAssignment.HoursWorked != request.HoursWorked) { selectedAssignment.HoursWorked = request.HoursWorked; }
            if (selectedAssignment.OrderLeader != request.OrderLeader) { selectedAssignment.OrderLeader = request.OrderLeader; }

            var prevoiusLeaderAssignments = await _context.Assignments
                                                          .Where(p => p.IdOrder == request.IdOrder)
                                                          .Where(p => p.OrderLeader == true)
                                                          .SingleOrDefaultAsync();

            if(prevoiusLeaderAssignments != null) prevoiusLeaderAssignments.OrderLeader = false;

            await _context.SaveChangesAsync();

            return new UpdateAssignmentResponse();
        }
    }
}
