using Application.Functions.DTOs;
using MediatR;

namespace Application.Functions.OrderItem.Commands.CreateOrderItemCommand
{
    public class CreateOrderItemCommand : IRequest<CreateOrderItemResponse>
    {
        public int IdOrder { get; set; }
        public int Circulation { get; set; }
        public int? Capacity { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public string InsideFormat { get; set; }
        public string CoverFormat { get; set; }
        public int IdDeliveryType { get; set; }
        public int? IdBindingType { get; set; }
        public int IdOrderItemType { get; set; }

        public ICollection<ColorDTO> Colors { get; set; }
        public ICollection<PaperDTO> Papers { get; set; }
        public ICollection<ServiceDTO> Services { get; set; }
    }
}
