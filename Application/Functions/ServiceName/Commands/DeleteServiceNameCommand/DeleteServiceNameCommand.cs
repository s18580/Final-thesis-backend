using MediatR;

namespace Application.Functions.ServiceName.Commands.DeleteServiceNameCommand
{
    public class DeleteServiceNameCommand : IRequest<DeleteServiceNameResponse>
    {
        public int IdServiceName { get; set; }
    }
}
