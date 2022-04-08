using MediatR;

namespace Application.Functions.Worksites.Commands.CreateWorksite
{
    public class CreateWorksiteCommand : IRequest<CreateWorksiteResponse>
    {
        public string Name { get; set; }
    }
}
