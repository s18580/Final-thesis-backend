using MediatR;

namespace Application.Functions.Worksites.Commands.UpdateWorksite
{
    public class UpdateWorksiteCommand : IRequest<UpdateWorksiteResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
