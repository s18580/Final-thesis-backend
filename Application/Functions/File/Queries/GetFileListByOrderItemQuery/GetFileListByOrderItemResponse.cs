using Application.Responses;
using FluentValidation.Results;

namespace Application.Functions.File.Queries.GetFileListByOrderItemQuery
{
    public class GetFileListByOrderItemResponse : BaseResponse
    {
        public List<Domain.Models.File> files { get; }

        public GetFileListByOrderItemResponse(List<Domain.Models.File> elements) : base()
        {
            files = elements;
        }

        public GetFileListByOrderItemResponse(ValidationResult validationResult, ResponseStatus status)
            : base(validationResult, status)
        { }

        public GetFileListByOrderItemResponse(string message, bool success, ResponseStatus status)
        : base(message, success, status)
        { }
    }
}
