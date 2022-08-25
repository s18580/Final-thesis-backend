using MediatR;

namespace Application.Functions.Workers.Queries.GetAWSCreds
{
    public class GetAWSCreds : IRequest<AWSCredsResponse>
    {
        public int Id { get; set; }
    }
}
