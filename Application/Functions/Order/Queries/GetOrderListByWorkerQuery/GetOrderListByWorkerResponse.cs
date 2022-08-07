using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Order.Queries.GetOrderListByWorkerQuery
{
    public class GetOrderListByWorkerResponse : BaseResponse
    {
        public List<Domain.Models.Order> Orders { get; }

        public GetOrderListByWorkerResponse(List<Domain.Models.Order> orders) : base()
        {
            Orders = orders;
        }

        public GetOrderListByWorkerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetOrderListByWorkerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
