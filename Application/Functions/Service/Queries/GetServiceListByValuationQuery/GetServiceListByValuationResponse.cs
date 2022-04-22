using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Service.Queries.GetServiceListByValuationQuery
{
    public class GetServiceListByValuationResponse : BaseResponse
    {
        public List<Domain.Models.Service> services { get; }

        public GetServiceListByValuationResponse(List<Domain.Models.Service> elements) : base()
        {
            services = elements;
        }

        public GetServiceListByValuationResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetServiceListByValuationResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
