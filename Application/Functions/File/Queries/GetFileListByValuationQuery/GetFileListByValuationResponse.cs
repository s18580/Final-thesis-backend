using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.File.Queries.GetFileListByValuationQuery
{
    public class GetFileListByValuationResponse : BaseResponse
    {
        public List<Domain.Models.File> files { get; }

        public GetFileListByValuationResponse(List<Domain.Models.File> elements) : base()
        {
            files = elements;
        }

        public GetFileListByValuationResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetFileListByValuationResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
