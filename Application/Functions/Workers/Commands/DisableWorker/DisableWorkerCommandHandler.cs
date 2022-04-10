using Application.Services;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Application.Functions.Workers.Commands.DisableWorker
{
    public class DisableWorkerCommandHandler : IRequestHandler<DisableWorkerCommand, DisableWorkerResponse>
    {
        private readonly IApplicationContext _context;

        public DisableWorkerCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DisableWorkerResponse> Handle(DisableWorkerCommand request, CancellationToken cancellationToken)
        {
            var validator = new DisableWorkerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DisableWorkerResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var worker = await _context.Workers.Where(p => p.IdWorker == request.Id).SingleAsync();
            worker.IsDisabled = request.IsDisabled;

            await _context.SaveChangesAsync();

            return new DisableWorkerResponse();
        }
    }
}
