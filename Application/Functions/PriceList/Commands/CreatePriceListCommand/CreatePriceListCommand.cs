using MediatR;

namespace Application.Functions.PriceList.Commands.CreatePriceListCommand
{
    public class CreatePriceListCommand : IRequest<CreatePriceListResponse>
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
