using MediatR;

namespace Application.Functions.Service.Commands.CreateServiceCommand
{
    public class CreateServiceCommand : IRequest<CreateServiceResponse>
    {
        public double Price { get; set; }
        public int IdLink { get; set; }
        public int? IdServiceName { get; set; }
        public bool IsForCover { get; set; }
    }
}
