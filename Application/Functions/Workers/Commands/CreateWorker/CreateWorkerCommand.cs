using MediatR;

namespace Application.Functions.Workers.Commands.CreateWorker
{
    public class CreateWorkerCommand : IRequest<CreateWorkerResponse>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public int? IdWorksite { get; set; }
    }
}
