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
            if (selectedValuation.Recipient != request.Recipient) { selectedValuation.Recipient = request.Recipient; }
            if (selectedValuation.InsideCirculation != request.InsideCirculation) { selectedValuation.InsideCirculation = request.InsideCirculation; }
            if (selectedValuation.InsideSheetNumber != request.InsideSheetNumber) { selectedValuation.InsideSheetNumber = request.InsideSheetNumber; }
            if (selectedValuation.CoverSheetNumber != request.CoverSheetNumber) { selectedValuation.CoverSheetNumber = request.CoverSheetNumber; }
            if (selectedValuation.InsideOther != request.InsideOther) { selectedValuation.InsideOther = request.InsideOther; }
            if (selectedValuation.CoverOther != request.CoverOther) { selectedValuation.CoverOther = request.CoverOther; }
            if (selectedValuation.CoverCirculation != request.CoverCirculation) { selectedValuation.CoverCirculation = request.CoverCirculation; }
            if (selectedValuation.InsidePlateNumber != request.InsidePlateNumber) { selectedValuation.InsidePlateNumber = request.InsidePlateNumber; }
            if (selectedValuation.CoverPlateNumber != request.CoverPlateNumber) { selectedValuation.CoverPlateNumber = request.CoverPlateNumber; }
            if (selectedValuation.MainCirculation != request.MainCirculation) { selectedValuation.MainCirculation = request.MainCirculation; }
            if (selectedValuation.FinalPrice != request.FinalPrice) { selectedValuation.FinalPrice = request.FinalPrice; }
            if (selectedValuation.IdOrderItem != request.IdOrderItem) { selectedValuation.IdOrderItem = request.IdOrderItem; }
            if (selectedValuation.Capacity != request.Capacity) { selectedValuation.Capacity = request.Capacity; }
            if (selectedValuation.InsideFormat != request.InsideFormat) { selectedValuation.InsideFormat = request.InsideFormat; }
            if (selectedValuation.CoverFormat != request.CoverFormat) { selectedValuation.CoverFormat = request.CoverFormat; }
            if (selectedValuation.InsideSheetFormat != request.InsideSheetFormat) { selectedValuation.InsideSheetFormat = request.InsideSheetFormat; }
            if (selectedValuation.CoverSheetFormat != request.CoverSheetFormat) { selectedValuation.CoverSheetFormat = request.CoverSheetFormat; }
            if (selectedValuation.IdBindingType != request.IdBindingType) { selectedValuation.IdBindingType = request.IdBindingType; }

            await _context.SaveChangesAsync();

            return new UpdateValuationResponse();
        }
    }
}
