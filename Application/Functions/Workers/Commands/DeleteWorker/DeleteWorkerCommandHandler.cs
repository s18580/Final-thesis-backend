using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Workers.Commands.DeleteWorker
{
    public class DeleteWorkerCommandHandler : IRequestHandler<DeleteWorkerCommand, DeleteWorkerResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteWorkerCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteWorkerResponse> Handle(DeleteWorkerCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteWorkerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteWorkerResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedWorker = await _context.Workers.Where(p => p.IdWorker == request.Id).SingleAsync();
            selectedWorker.PhoneNumber = "";
            selectedWorker.Password = null;
            selectedWorker.Salt = null;
            selectedWorker.AccessKeyAWS = "";
            selectedWorker.SecretKeyAWS = "";
            selectedWorker.IdWorksite = null;

            var roleAssignments = await _context.RoleAssignments.Where(p => p.IdWorker == selectedWorker.IdWorker).ToListAsync();
            foreach (var roleAssignment in roleAssignments)
            {
                _context.RoleAssignments.Remove(roleAssignment);
                await _context.SaveChangesAsync();
            }

            _context.Workers.Remove(selectedWorker);
            await _context.SaveChangesAsync();

            return new DeleteWorkerResponse();
        }
    }
}
