using MediatR;

namespace Application.Functions.Service.Commands.CreateServiceCommand
{
    public class CreateServiceCommand : IRequest<CreateServiceResponse>
    {
        public double Price { get; set; }
        public int? IdOrderItem { get; set; }
        public int? IdValuation { get; set; }
        public int? IdServiceName { get; set; }
    }
}
