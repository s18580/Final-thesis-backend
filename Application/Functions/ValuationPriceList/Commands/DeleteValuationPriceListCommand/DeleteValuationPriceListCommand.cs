using MediatR;

namespace Application.Functions.ValuationPriceList.Commands.DeleteValuationPriceListCommand
{
    public class DeleteValuationPriceListCommand : IRequest<DeleteValuationPriceListResponse>
    {
        public int IdValuation { get; set; }
        public int IdPriceList { get; set; }
    }
}
