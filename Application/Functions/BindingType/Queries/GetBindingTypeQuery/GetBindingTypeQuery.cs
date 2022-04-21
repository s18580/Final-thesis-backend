using MediatR;

namespace Application.Functions.BindingType.Queries.GetBindingTypeQuery
{
    public class GetBindingTypeQuery : IRequest<Domain.Models.DictionaryModels.BindingType>
    {
        public int IdBindingType { get; set; }
    }
}
