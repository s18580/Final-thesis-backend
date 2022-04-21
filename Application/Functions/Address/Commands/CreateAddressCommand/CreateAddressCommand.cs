﻿using MediatR;

namespace Application.Functions.Address.Commands.CreateAddressCommand
{
    public class CreateAddressCommand : IRequest<CreateAddressResponse>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int? PostCode { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string ApartmentNumber { get; set; }
        public int IdOwner { get; set; }
    }
}