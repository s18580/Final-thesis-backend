using Application.Services;
using Application.Functions.DTOs.SearchersDTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Representative.Queries.GetSearchRepresentativeListQuery
{
    public class GetSearchRepresentativeListQueryHandler : IRequestHandler<GetSearchRepresentativeListQuery, List<SearchRepresentativeDTO>>
    {
        private readonly IApplicationContext _context;

        public GetSearchRepresentativeListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<SearchRepresentativeDTO>> Handle(GetSearchRepresentativeListQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Models.Representative> representatives = new List<Domain.Models.Representative>();
            if (request.Name.Equals("null") && request.LastName.Equals("null") && request.Email.Equals("null") && request.Phone.Equals("null") && request.Customer.Equals("null") && request.Supplier.Equals("null"))
            {
                representatives = await _context.Representatives
                                                .Include(x => x.Customer)
                                                .Include(b => b.Supplier)
                                                .Where(p => p.IsDisabled == request.IsDisabled)
                                                .ToListAsync();
            }
            else
            {
                representatives = await _context.Representatives
                                                .Include(x => x.Customer)
                                                .Include(b => b.Supplier)
                                                .Where(b => (b.Name == request.Name || b.LastName == request.LastName || b.PhoneNumber == request.Phone || b.EmailAddress == request.Email || b.Supplier.Name == request.Supplier || b.Customer.CompanyName == request.Customer) && b.IsDisabled == request.IsDisabled)
                                                .ToListAsync();
            }

            var representativesDTO = new List<SearchRepresentativeDTO>();

            foreach (Domain.Models.Representative representative in representatives)
            {
                var repName = "";
                if (representative.Customer != null)
                {
                    repName = representative.Customer.CompanyName;
                }
                else if (representative.Supplier != null)
                {
                    repName = representative.Supplier.Name;
                }

                var representativeDTO = new SearchRepresentativeDTO
                {
                    IdRepresentative = representative.IdRepresentative,
                    Name = representative.Name,
                    LastName = representative.LastName,
                    PhoneNumber = representative.PhoneNumber,
                    EmailAddress = representative.EmailAddress,
                    RepresentativeName = repName
                };

                representativesDTO.Add(representativeDTO);
            }

            return representativesDTO;
        }
    }
}
