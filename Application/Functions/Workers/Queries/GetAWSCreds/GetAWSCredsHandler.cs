using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Workers.Queries.GetAWSCreds
{
    public class GetAWSCredsHandler : IRequestHandler<GetAWSCreds, AWSCredsResponse>
    {
        private readonly IApplicationContext _context;

        public GetAWSCredsHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<AWSCredsResponse> Handle(GetAWSCreds request, CancellationToken cancellationToken)
        {
            var worker = await _context.Workers
                                       .Where(p => p.IdWorker == request.Id)
                                       .SingleOrDefaultAsync();

            if (worker != null)
            {
                return new AWSCredsResponse(worker.AccessKeyAWS, worker.SecretKeyAWS);
            }
            else
            {
                return null;
            }
        }
    }
}
