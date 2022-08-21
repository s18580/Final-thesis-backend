using Application.Functions.DTOs.SearchersDTOs;
using Application.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Functions.Customer.Queries.GetSearchCustomerListQuery
{
    public class GetSearchCustomerListQueryHandler : IRequestHandler<GetSearchCustomerListQuery, List<SearchCustomerDTO>>
    {
        private readonly IApplicationContext _context;

        public GetSearchCustomerListQueryHandler(IApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<SearchCustomerDTO>> Handle(GetSearchCustomerListQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Models.Customer> customers = new List<Domain.Models.Customer>();
            if (request.CustomerName.Equals("null") && request.CustomerPhone.Equals("null") && request.CustomerEmail.Equals("null") && request.NIP.Equals("null") && request.REGON.Equals("null") && request.RepresentativeName.Equals("null") && request.RepresentativeLastName.Equals("null") && request.RepresentativePhone.Equals("null") && request.RepresentativeEmail.Equals("null") && request.WorkerLeader.Equals("null"))
            {
                customers = await _context.Customers
                                          .Include(m => m.Worker)
                                          .ToListAsync();
            }
            else
            {
                customers = await _context.Customers
                                          .Include(m => m.Worker)
                                          .Where(p => p.CompanyName == request.CustomerName || p.CompanyPhoneNumber == request.CustomerPhone || p.CompanyEmailAddress == request.CustomerEmail || p.NIP == request.NIP || p.Regon == request.REGON || (p.Worker.Name + " " + p.Worker.LastName) == request.WorkerLeader || 
                                                 p.Representatives.Where(m => m.Name == request.RepresentativeName).Count() > 0 || p.Representatives.Where(m => m.LastName == request.RepresentativeLastName).Count() > 0 || p.Representatives.Where(m => m.PhoneNumber == request.RepresentativePhone).Count() > 0 || p.Representatives.Where(m => m.EmailAddress == request.RepresentativeEmail).Count() > 0)
                                          .ToListAsync();
            }

            var customersDTO = new List<SearchCustomerDTO>();
            foreach (Domain.Models.Customer customer in customers)
            {
                var customerDTO = new SearchCustomerDTO
                {
                    IdCustomer = customer.IdCustomer,
                    CustomerName = customer.CompanyName,
                    CustomerPhone = customer.CompanyPhoneNumber,
                    CustomerEmail = customer.CompanyEmailAddress,
                    NIP = customer.NIP,
                    REGON = customer.Regon,
                    WorkerLeader = customer.Worker.Name + " " + customer.Worker.LastName
                };

                customersDTO.Add(customerDTO);
            }

            return customersDTO;
        }
    }
}
