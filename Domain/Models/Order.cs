using Domain.Models.DictionaryModels;

namespace Domain.Models
{
    public class Order
    {
        public int IdOrder { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? OrderSubmissionDate { get; set; }
        public string Note { get; set; }
        public bool IsAuction { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? OfferValidityDate { get; set; }
        public int IdRepresentative { get; set; }
        public int IdStatus { get; set; }

        public Representative Representative { get; set; }
        public OrderStatus Status { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public ICollection<File> Files { get; set; }
        public ICollection<DeliveriesAddresses> DeliveriesAddresses { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
