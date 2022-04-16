using MediatR;

namespace Application.Functions.Order.Commands.CreateOrderCommand
{
    public class CreateOrderCommand : IRequest<CreateOrderResponse>
    {
        public string Name { get; set; }
        public DateTime? OrderSubmissionDate { get; set; }
        public string Note { get; set; }
        public bool IsAuction { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? OfferValidityDate { get; set; }
        public int IdRepresentative { get; set; }
        public int IdStatus { get; set; }
    }
}
