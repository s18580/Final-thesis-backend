using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Order.Queries.GetOrderListByWorkerQuery
{
    public class GetOrderListByWorkerResponse : BaseResponse
    {
        public List<TableOrderListDTO> Orders { get; }

        public GetOrderListByWorkerResponse(List<TableOrderListDTO> orders) : base()
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
