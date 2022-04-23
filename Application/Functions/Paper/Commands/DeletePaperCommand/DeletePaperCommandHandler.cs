using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Paper.Commands.DeletePaperCommand
{
    public class DeletePaperCommandHandler : IRequestHandler<DeletePaperCommand, DeletePaperResponse>
    {
        private readonly IApplicationContext _context;

        public DeletePaperCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeletePaperResponse> Handle(DeletePaperCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeletePaperValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeletePaperResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var paperDelete = await _context.Papers
                                            .Where(p => p.IdPaper == request.IdPaper)
                                            .SingleAsync();

            _context.Papers.Remove(paperDelete);
            await _context.SaveChangesAsync();

            return new DeletePaperResponse();
        }
    }
}
