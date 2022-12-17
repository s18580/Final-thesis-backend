using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.File.Commands.DeleteFileCommand
{
    public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, DeleteFileResponse>
    {
        private readonly IApplicationContext _context;
        public DeleteFileCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteFileResponse> Handle(DeleteFileCommand request, CancellationToken cancellationToken)
        {

            var validator = new DeleteFileValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteFileResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var fileDelete = await _context.Files
                                           .Where(p => p.FileKey == request.FileKey)
                                           .SingleAsync();

            _context.Files.Remove(fileDelete);
            await _context.SaveChangesAsync();


            return new DeleteFileResponse();
        }
    }
}
