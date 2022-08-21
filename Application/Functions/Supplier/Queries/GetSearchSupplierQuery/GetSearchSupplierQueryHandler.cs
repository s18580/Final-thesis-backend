using Application.Functions.DTOs.SearchersDTOs;
using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Supplier.Queries.GetSearchSupplierQuery
{
    public class GetSearchSupplierQueryHandler : IRequestHandler<GetSearchSupplierQuery, List<SearchSupplierDTO>>
    {
        private readonly IApplicationContext _context;

        public GetSearchSupplierQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<SearchSupplierDTO>> Handle(GetSearchSupplierQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Models.Supplier> suppliers = new List<Domain.Models.Supplier>();
            if (request.SupplierName.Equals("null") && request.RepresentativeName.Equals("null") && request.RepresentativeLastName.Equals("null") && request.Description.Equals("null") && request.City.Equals("null") && request.Street.Equals("null") && request.AddressName.Equals("null") && request.EmailAddress.Equals("null") && request.PhoneNumber.Equals("null"))
            {
                suppliers = await _context.Suppliers
                                         .Include(m => m.Addresses)
                                         .Include(m => m.Representatives)
                                         .ToListAsync();
            }
            else
            {
                suppliers = await _context.Suppliers
                                          .Include(m => m.Addresses)
                                          .Include(m => m.Representatives)
                                          .Where(p => p.Name == request.SupplierName || p.PhoneNumber == request.PhoneNumber || p.EmailAddress == request.EmailAddress || p.Addresses.Where(m => m.Name == request.AddressName).Count() > 0 || p.Addresses.Where(m => m.City == request.City).Count() > 0 || p.Addresses.Where(m => m.StreetName == request.Street).Count() > 0 || p.Representatives.Where( m => m.Name == request.RepresentativeName).Count() > 0 || p.Representatives.Where(m => m.LastName == request.RepresentativeLastName).Count() > 0 || p.Description.Contains(request.Description))
                                          .ToListAsync();
            }

            var suppliersDTO = new List<SearchSupplierDTO>();
            foreach (Domain.Models.Supplier supplier in suppliers)
            {
                var addressesNames = "";
                var representativesNames = "";
                foreach (var address in supplier.Addresses)
                {
                    addressesNames = addressesNames + address.Name + ", ";
                }

                foreach (var representative in supplier.Representatives)
                {
                    representativesNames = representativesNames + representative.Name + " " + representative.LastName + ", ";
                }

                var supplierDTO = new SearchSupplierDTO
                {
                    IdSupplier = supplier.IdSupplier,
                    Name = supplier.Name,
                    PhoneNumber = supplier.PhoneNumber,
                    EmailAddress = supplier.EmailAddress,
                    RepresentativeName = representativesNames,
                    AddressName = addressesNames,
                };

                suppliersDTO.Add(supplierDTO);
            }

            return suppliersDTO;
        }
    }
}
