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
            selectedWorker.PhoneNumber = null;
            selectedWorker.PassHash = null;
            selectedWorker.IdWorksite = null;

            await _context.SaveChangesAsync();

            return new DeleteWorkerResponse();
        }
    }
}
