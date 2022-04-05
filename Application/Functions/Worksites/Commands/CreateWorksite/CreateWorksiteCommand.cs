using MediatR;

namespace Application.Functions.Worksites.Commands.CreateWorksite
{
    public class CreateWorksiteCommand : IRequest<CreateWorksiteResponse>
    {
        public int IdWorksite { get; set; }
        public string Name { get; set; }
    }
}
