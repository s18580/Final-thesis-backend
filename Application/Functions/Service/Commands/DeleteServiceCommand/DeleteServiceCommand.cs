using MediatR;

namespace Application.Functions.Service.Commands.DeleteServiceCommand
{
    public class DeleteServiceCommand : IRequest<DeleteServiceResponse>
    {
        public int IdService { get; set; }
    }
}
