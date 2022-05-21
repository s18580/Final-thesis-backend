using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Address.Queries.GetAddressListByCustomerIdQuery
{
    public class GetAddressListByCustomerIdResponse : BaseResponse
    {
        public List<Domain.Models.Address> address { get; }

        public GetAddressListByCustomerIdResponse(List<Domain.Models.Address> elements) : base()
        {
            address = elements;
        }

        public GetAddressListByCustomerIdResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetAddressListByCustomerIdResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}