using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Representative.Queries.GetRepresentativeListByCustomerQuery
{
    public class GetRepresentativeListByCustomerResponse : BaseResponse
    {
        public List<Domain.Models.Representative> Representatives { get; set; }

        public GetRepresentativeListByCustomerResponse(List<Domain.Models.Representative> representatives) : base()
        {
            Representatives = representatives;
        }

        public GetRepresentativeListByCustomerResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetRepresentativeListByCustomerResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
