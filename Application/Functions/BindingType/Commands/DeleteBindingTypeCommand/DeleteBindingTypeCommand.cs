using MediatR;

namespace Application.Functions.BindingType.Commands.DeleteBindingTypeCommand
{
    public class DeleteBindingTypeCommand : IRequest<DeleteBindingTypeResponse>
    {
        public int IdBindingType { get; set; }
    }
}
