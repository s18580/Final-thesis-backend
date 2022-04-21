using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.OrderItem.Queries.GetOrderItemListByOrderIdQuery
{
    public class GetOrderItemListByOrderIdResponse : BaseResponse
    {
        public List<Domain.Models.OrderItem> orderItems { get; }

        public GetOrderItemListByOrderIdResponse(List<Domain.Models.OrderItem> elements) : base()
        {
            orderItems = elements;
        }

        public GetOrderItemListByOrderIdResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetOrderItemListByOrderIdResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
