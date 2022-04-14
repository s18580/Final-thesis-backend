using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.FileStatus.Commands.DeleteFileStatusCommand
{
    public class DeleteFileStatusCommandHandler : IRequestHandler<DeleteFileStatusCommand, DeleteFileStatusResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteFileStatusCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteFileStatusResponse> Handle(DeleteFileStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteFileStatusValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteFileStatusResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var fileStatusDelete = await _context.FileStatuses
                                                  .Where(p => p.IdFileStatus == request.IdFileStatus)
                                                  .SingleAsync();

            _context.FileStatuses.Remove(fileStatusDelete);
            await _context.SaveChangesAsync();

            return new DeleteFileStatusResponse();
        }
    }
}
