using Application.Functions.DTOs;
using MediatR;

namespace Application.Functions.Order.Commands.CreateOrderWithDataCommand
{
    public class CreateOrderWithDataCommand : IRequest<CreateOrderWithDataResponse>
    {
        public string Name { get; set; }
        public DateTime? OrderSubmissionDate { get; set; }
        public string Note { get; set; }
        public bool IsAuction { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? OfferValidityDate { get; set; }
        public int IdRepresentative { get; set; }
        public int IdStatus { get; set; }
        public int IdCustomer { get; set; }

        public ICollection<AddressDTO> DeliveryAddresses { get; set; }
        public ICollection<WorkerAssignmentDTO> WorkersToAssign { get; set; }
        public ICollection<OrderItemDTO> OrderItems { get; set; }
    }
}
