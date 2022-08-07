using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Order.Queries.GetOrderListByWorkerQuery
{
    public class GetOrderListByWorkerQueryHandler : IRequestHandler<GetOrderListByWorkerQuery, GetOrderListByWorkerResponse>
    {
        private readonly IApplicationContext _context;

        public GetOrderListByWorkerQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<GetOrderListByWorkerResponse> Handle(GetOrderListByWorkerQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetOrderListByWorkerValidator(_context);
            var validatorResult = await validator.ValidateAsync(request);

            if (!validatorResult.IsValid) return new GetOrderListByWorkerResponse(validatorResult, Responses.ResponseStatus.ValidationError);

            var assignmentsWithOrders = await _context.Assignments
                                         .Include(b => b.Order)
                                         .Where(p => p.IdWorker == request.IdWorker)
                                         .Where(p => p.OrderLeader == true)
                                         .ToListAsync();

            List<Domain.Models.Order> orders = new List<Domain.Models.Order>();

            foreach(Domain.Models.Assignment assignment in assignmentsWithOrders)
            {
                var order = assignment.Order;
                order.Assignments = null;
                orders.Add(order);
            }

            return new GetOrderListByWorkerResponse(orders);
        }
    }
}
