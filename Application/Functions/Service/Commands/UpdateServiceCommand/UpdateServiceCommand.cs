using MediatR;

namespace Application.Functions.Service.Commands.UpdateServiceCommand
{
    public class UpdateServiceCommand : IRequest<UpdateServiceResponse>
    {
        public int IdService { get; set; }
        public double Price { get; set; }
    }
}
