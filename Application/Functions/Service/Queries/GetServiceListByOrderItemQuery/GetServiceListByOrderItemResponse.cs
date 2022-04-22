using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Service.Queries.GetServiceListByOrderItemQuery
{
    public class GetServiceListByOrderItemResponse : BaseResponse
    {
        public List<Domain.Models.Service> services { get; }

        public GetServiceListByOrderItemResponse(List<Domain.Models.Service> elements) : base()
        {
            services = elements;
        }

        public GetServiceListByOrderItemResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetServiceListByOrderItemResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
