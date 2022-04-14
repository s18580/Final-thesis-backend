using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.FileStatus.Commands.UpdateFileStatusCommand
{
    public class UpdateFileStatusCommandHandler : IRequestHandler<UpdateFileStatusCommand, UpdateFileStatusResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateFileStatusCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateFileStatusResponse> Handle(UpdateFileStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFileStatusValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateFileStatusResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedFileStatus = await _context.FileStatuses
                                                   .Where(p => p.IdFileStatus == request.IdFileStatus)
                                                   .SingleAsync();

            if (selectedFileStatus.Name != request.Name) { selectedFileStatus.Name = request.Name; }

            await _context.SaveChangesAsync();

            return new UpdateFileStatusResponse();
        }
    }
}
