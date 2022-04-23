using MediatR;

namespace Application.Functions.PriceList.Commands.DeletePriceListCommand
{
    public class DeletePriceListCommand : IRequest<DeletePriceListResponse>
    {
        public int IdPriceList { get; set; }
    }
}
