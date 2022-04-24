using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Valuation.Commands.UpdateValuationCommand
{
    public class UpdateValuationCommandHandler : IRequestHandler<UpdateValuationCommand, UpdateValuationResponse>
    {
        private readonly IApplicationContext _context;

        public UpdateValuationCommandHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<UpdateValuationResponse> Handle(UpdateValuationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateValuationValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new UpdateValuationResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var selectedValuation = await _context.Valuations
                                                  .Where(p => p.IdValuation == request.IdValuation)
                                                  .SingleAsync();

            if (selectedValuation.Name != request.Name) { selectedValuation.Name = request.Name; }
            if (selectedValuation.OfferValidityDate != request.OfferValidityDate) { selectedValuation.OfferValidityDate = request.OfferValidityDate; }
            if (selectedValuation.GraphicDesignPrice != request.GraphicDesignPrice) { selectedValuation.GraphicDesignPrice = request.GraphicDesignPrice; }
            if (selectedValuation.SamplePrintoutsPrice != request.SamplePrintoutsPrice) { selectedValuation.SamplePrintoutsPrice = request.SamplePrintoutsPrice; }
            if (selectedValuation.PrintingOnReverse != request.PrintingOnReverse) { selectedValuation.PrintingOnReverse = request.PrintingOnReverse; }
            if (selectedValuation.UnitPriceNet != request.UnitPriceNet) { selectedValuation.UnitPriceNet = request.UnitPriceNet; }
            if (selectedValuation.Circulation != request.Circulation) { selectedValuation.Circulation = request.Circulation; }
            if (selectedValuation.Capacity != request.Capacity) { selectedValuation.Capacity = request.Capacity; }
            if (selectedValuation.InsideFormat != request.InsideFormat) { selectedValuation.InsideFormat = request.InsideFormat; }
            if (selectedValuation.CoverFormat != request.CoverFormat) { selectedValuation.CoverFormat = request.CoverFormat; }
            if (selectedValuation.InsideSheetFormat != request.InsideSheetFormat) { selectedValuation.InsideSheetFormat = request.InsideSheetFormat; }
            if (selectedValuation.CoverSheetFormat != request.CoverSheetFormat) { selectedValuation.CoverSheetFormat = request.CoverSheetFormat; }
            if (selectedValuation.PrintingPlateNuber != request.PrintingPlateNuber) { selectedValuation.PrintingPlateNuber = request.PrintingPlateNuber; }
            if (selectedValuation.PrintPrice != request.PrintPrice) { selectedValuation.PrintPrice = request.PrintPrice; }
            if (selectedValuation.IdBindingType != request.IdBindingType) { selectedValuation.IdBindingType = request.IdBindingType; }

            await _context.SaveChangesAsync();

            return new UpdateValuationResponse();
        }
    }
}
