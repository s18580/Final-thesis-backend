using MediatR;

namespace Application.Functions.ServiceName.Commands.CreateServiceNameCommand
{
    public class CreateServiceNameCommand : IRequest<CreateServiceNameResponse>
    {
        public string Name { get; set; }
        public double? DefaultPrice { get; set; }
        public double? MinimumPrice { get; set; }
        public int? MinimumCirculation { get; set; }
    }
}
