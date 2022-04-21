using MediatR;

namespace Application.Functions.BindingType.Commands.UpdateBindingTypeCommand
{
    public class UpdateBindingTypeCommand : IRequest<UpdateBindingTypeResponse>
    {
        public int IdBindingType { get; set; }
        public string Name { get; set; }
    }
}
