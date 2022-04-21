using MediatR;

namespace Application.Functions.BindingType.Commands.CreateBindingTypeCommand
{
    public class CreateBindingTypeCommand : IRequest<CreateBindingTypeResponse>
    {
        public string Name { get; set; }
    }
}
