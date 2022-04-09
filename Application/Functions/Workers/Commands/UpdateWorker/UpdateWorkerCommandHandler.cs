using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Workers.Commands.UpdateWorker
{
    public class UpdateWorkerCommandHandler : IRequestHandler<UpdateWorkerCommand, UpdateWorkerResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateWorkerCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateWorkerResponse> Handle(UpdateWorkerCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateWorkerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateWorkerResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedWorker = await _context.Workers.Where(p => p.IdWorker == request.Id).SingleAsync();

            if (selectedWorker.Name != request.Name) { selectedWorker.Name = request.Name; }
            if (selectedWorker.LastName != request.LastName) { selectedWorker.LastName = request.LastName; }
            if (selectedWorker.PhoneNumber != request.PhoneNumber) { selectedWorker.PhoneNumber = request.PhoneNumber; }
            if (selectedWorker.EmailAddres != request.EmailAddres) { selectedWorker.EmailAddres = request.EmailAddres; }

            await _context.SaveChangesAsync();

            return new UpdateWorkerResponse();
        }
    }
}