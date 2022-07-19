using MediatR;

namespace Application.Functions.Worksites.Commands.UpdateWorksite
{
    public class UpdateWorksiteCommand : IRequest<UpdateWorksiteResponse>
    {
        public int IdWorksite { get; set; }
        public string Name { get; set; }
    }
}
