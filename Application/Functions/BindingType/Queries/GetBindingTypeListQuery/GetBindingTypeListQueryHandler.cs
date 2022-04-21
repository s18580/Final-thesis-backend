using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.BindingType.Queries.GetBindingTypeListQuery
{
    public class GetBindingTypeListQueryHandler : IRequestHandler<GetBindingTypeListQuery, List<Domain.Models.DictionaryModels.BindingType>>
    {
        private readonly IApplicationContext _context;

        public GetBindingTypeListQueryHandler(IApplicationContext context)
        {
            _context = context;

        }

        public async Task<List<Domain.Models.DictionaryModels.BindingType>> Handle(GetBindingTypeListQuery request, CancellationToken cancellationToken)
        {
            var bindingTypes = await _context.BindingTypes
                                             .ToListAsync();

            return bindingTypes;
        }
    }
}
