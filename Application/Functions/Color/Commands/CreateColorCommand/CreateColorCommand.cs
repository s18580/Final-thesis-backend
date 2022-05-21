using MediatR;

namespace Application.Functions.Color.Commands.CreateColorCommand
{
    public class CreateColorCommand : IRequest<CreateColorResponse>
    {
        public string Name { get; set; }
        public int? IdValuation { get; set; }
        public int? IdOrderItem { get; set; }
    }
}
