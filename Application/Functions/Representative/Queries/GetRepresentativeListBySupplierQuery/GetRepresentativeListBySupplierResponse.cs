using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.Representative.Queries.GetRepresentativeListBySupplierQuery
{
    public class GetRepresentativeListBySupplierResponse : BaseResponse
    {
        public List<Domain.Models.Representative> Representatives { get; set; }

        public GetRepresentativeListBySupplierResponse(List<Domain.Models.Representative> representatives) : base()
        {
            Representatives = representatives;
        }

        public GetRepresentativeListBySupplierResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetRepresentativeListBySupplierResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
