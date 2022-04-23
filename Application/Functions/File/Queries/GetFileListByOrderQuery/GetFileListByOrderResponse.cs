using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.File.Queries.GetFileListByOrderQuery
{
    public class GetFileListByOrderResponse : BaseResponse
    {
        public List<Domain.Models.File> files { get; }

        public GetFileListByOrderResponse(List<Domain.Models.File> elements) : base()
        {
            files = elements;
        }

        public GetFileListByOrderResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetFileListByOrderResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
