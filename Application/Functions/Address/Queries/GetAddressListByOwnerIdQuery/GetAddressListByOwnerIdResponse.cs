using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Address.Queries.GetAddressListByOwnerIdQuery
{
    public class GetAddressListByOwnerIdResponse : BaseResponse
    {
        public List<Domain.Models.Address> address { get; }

        public GetAddressListByOwnerIdResponse(List<Domain.Models.Address> elements) : base()
        {
            address = elements;
        }

        public GetAddressListByOwnerIdResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetAddressListByOwnerIdResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
