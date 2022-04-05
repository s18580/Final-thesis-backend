using MediatR;

namespace Application.Functions.Worksites.Commands.DeleteWorksite
{
    public class DeleteWorksiteCommand : IRequest<DeleteWorksiteResponse>
    {
        public int Id { get; set; }
    }
}
