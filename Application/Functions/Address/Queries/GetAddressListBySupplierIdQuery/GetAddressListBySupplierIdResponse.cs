using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Address.Queries.GetAddressListBySupplierIdQuery
{
    public class GetAddressListBySupplierIdResponse : BaseResponse
    {
        public List<Domain.Models.Address> address { get; }

        public GetAddressListBySupplierIdResponse(List<Domain.Models.Address> elements) : base()
        {
            address = elements;
        }

        public GetAddressListBySupplierIdResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetAddressListBySupplierIdResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
