using MediatR;

namespace Application.Functions.ValuationPriceList.Commands.CreateValuationPriceListCommand
{
    public class CreateValuationPriceListCommand : IRequest<CreateValuationPriceListResponse>
    {
        public int IdValuation { get; set; }
        public int IdPriceList { get; set; }
    }
}
