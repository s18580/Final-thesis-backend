using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Worksites.Commands.DeleteWorksite
{
    public class DeleteWorksiteCommandHandler : IRequestHandler<DeleteWorksiteCommand, DeleteWorksiteResponse>
    {
        private readonly IApplicationContext _context;

        public DeleteWorksiteCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<DeleteWorksiteResponse> Handle(DeleteWorksiteCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteWorksiteValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new DeleteWorksiteResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var worksiteToDelete = await _context.Worksites.Where(p => p.IdWorksite == request.IdWorksite).SingleAsync();

            _context.Worksites.Remove(worksiteToDelete);
            await _context.SaveChangesAsync();

            return new DeleteWorksiteResponse();
        }
    }
}
