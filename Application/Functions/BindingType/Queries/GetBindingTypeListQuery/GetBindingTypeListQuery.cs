using MediatR;

namespace Application.Functions.BindingType.Queries.GetBindingTypeListQuery
{
    public class GetBindingTypeListQuery : IRequest<List<Domain.Models.DictionaryModels.BindingType>>
    {
    }
}
