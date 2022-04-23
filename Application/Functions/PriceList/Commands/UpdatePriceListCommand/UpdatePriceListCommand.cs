using MediatR;

namespace Application.Functions.PriceList.Commands.UpdatePriceListCommand
{
    public class UpdatePriceListCommand : IRequest<UpdatePriceListResponse>
    {
        public int IdPriceList { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
