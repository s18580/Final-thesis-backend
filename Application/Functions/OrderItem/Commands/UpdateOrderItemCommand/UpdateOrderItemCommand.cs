using MediatR;

namespace Application.Functions.OrderItem.Commands.UpdateOrderItemCommand
{
    public class UpdateOrderItemCommand : IRequest<UpdateOrderItemResponse>
    {
        public int IdOrderItem { get; set; }
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
        public int? IdSelectedValuation { get; set; }
        public ICollection<ColorUpdateDTO> Colors { get; set; }
        public ICollection<PaperUpdateDTO> Papers { get; set; }
        public ICollection<ServiceUpdateDTO> Services { get; set; }
    }
}
