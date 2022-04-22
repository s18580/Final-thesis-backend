using MediatR;

namespace Application.Functions.ServiceName.Commands.UpdateServiceNameCommand
{
    public class UpdateServiceNameCommand : IRequest<UpdateServiceNameResponse>
    {
        public int IdServiceName { get; set; }
        public string Name { get; set; }
        public double? DefaultPrice { get; set; }
        public double? MinimumPrice { get; set; }
        public int? MinimumCirculation { get; set; }
    }
}
