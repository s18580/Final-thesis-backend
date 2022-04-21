using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.BindingType.Queries.GetBindingTypeQuery
{
    public class GetBindingTypeQueryHandler : IRequestHandler<GetBindingTypeQuery, Domain.Models.DictionaryModels.BindingType>
    {
        private readonly IApplicationContext _context;

        public GetBindingTypeQueryHandler(IApplicationContext context)
        {
            _context = context;

        }

        public async Task<Domain.Models.DictionaryModels.BindingType> Handle(GetBindingTypeQuery request, CancellationToken cancellationToken)
        {
            var bindingType = await _context.BindingTypes
                                            .Where(p => p.IdBindingType == request.IdBindingType)
                                            .SingleOrDefaultAsync();

            return bindingType;
        }
    }
}
