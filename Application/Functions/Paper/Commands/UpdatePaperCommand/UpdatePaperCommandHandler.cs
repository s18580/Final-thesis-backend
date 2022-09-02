using Application.Services;
using Domain.Enumerators;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Paper.Commands.UpdatePaperCommand
{
    public class UpdatePaperCommandHandler : IRequestHandler<UpdatePaperCommand, UpdatePaperResponse>
    {
        private readonly IApplicationContext _context;

        public UpdatePaperCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdatePaperResponse> Handle(UpdatePaperCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePaperValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdatePaperResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedPaper = await _context.Papers
                                              .Where(p => p.IdPaper == request.IdPaper)
                                              .SingleAsync();

            if (selectedPaper.Name != request.Name) { selectedPaper.Name = request.Name; }
            if (selectedPaper.Kind != request.Kind) { selectedPaper.Kind = request.Kind; }
            if (selectedPaper.SheetFormat != request.SheetFormat) { selectedPaper.SheetFormat = request.SheetFormat; }
            if ((int)selectedPaper.FiberDirection != request.FiberDirection) { selectedPaper.FiberDirection = (FiberDirection)request.FiberDirection; }
            if (selectedPaper.Opacity != request.Opacity) { selectedPaper.Opacity = request.Opacity; }
            if (selectedPaper.IsForCover != request.IsForCover) { selectedPaper.IsForCover = request.IsForCover; }
            if (selectedPaper.PricePerKilogram != request.PricePerKilogram) { selectedPaper.PricePerKilogram = request.PricePerKilogram; }
            if (selectedPaper.Quantity != request.Quantity) { selectedPaper.Quantity = request.Quantity; }

            await _context.SaveChangesAsync();

            return new UpdatePaperResponse();
        }
    }
}
