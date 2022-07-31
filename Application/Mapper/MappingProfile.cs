using Application.Functions.Address.Commands.CreateAddressCommand;
using Application.Functions.Assignment.Commands.CreateAssignmentCommand;
using Application.Functions.BindingType.Commands.CreateBindingTypeCommand;
using Application.Functions.Color.Commands.CreateColorCommand;
using Application.Functions.Customer.Commands.CreateCompanyCustomerCommand;
using Application.Functions.Customer.Commands.CreatePersonCustomerCommand;
using Application.Functions.DeliveriesAddresses.Commands.CreateDeliveriesAddressesCommand;
using Application.Functions.DeliveryType.Commands.CreateDeliveryTypeCommand;
using Application.Functions.File.Commands.CreateFileCommand;
using Application.Functions.FileStatus.Commands.CreateFileStatusCommand;
using Application.Functions.FileType.Commands.CreateFileTypeCommand;
using Application.Functions.OrderItem.Commands.CreateOrderItemCommand;
using Application.Functions.OrderItemType.Commands.CreateOrderItemTypeCommand;
using Application.Functions.OrderStatus.Commands.CreateOrderStatusCommand;
using Application.Functions.Paper.Commands.CreatePaperCommand;
using Application.Functions.PriceList.Commands.CreatePriceListCommand;
using Application.Functions.Representative.Commands.CreateRepresentativeCommand;
using Application.Functions.RoleAssignment.Commands.CreateRoleAssignmentCommand;
using Application.Functions.Roles.Commands.CreateRole;
using Application.Functions.Service.Commands.CreateServiceCommand;
using Application.Functions.ServiceName.Commands.CreateServiceNameCommand;
using Application.Functions.Supplier.Commands.CreateSupplierCommand;
using Application.Functions.Supply.Commands.CreateSupplyCommand;
using Application.Functions.SupplyItemType.Commands.CreateSupplyItemTypeCommand;
using Application.Functions.User;
using Application.Functions.User.Commands.RegisterUserCommand;
using Application.Functions.Valuation.Commands.CreateValuationCommand;
using Application.Functions.ValuationPriceList.Commands.CreateValuationPriceListCommand;
using Application.Functions.Workers;
using Application.Functions.Worksites.Commands.CreateWorksite;
using AutoMapper;
using Domain.Models;
using Domain.Models.DictionaryModels;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Worksite, CreateWorksiteCommand>().ReverseMap();
            CreateMap<Role, CreateRoleCommand>().ReverseMap();
            CreateMap<RegisterUserCommand, Worker>().ForMember(d => d.Password, opt => opt.Ignore()).ReverseMap();
            CreateMap<Worker, WorkerDTO>().ReverseMap();
            CreateMap<RoleAssignment, CreateRoleAssignmentCommand>().ReverseMap();
            CreateMap<SupplyItemType, CreateSupplyItemTypeCommand>().ReverseMap();
            CreateMap<OrderItemType, CreateOrderItemTypeCommand>().ReverseMap();
            CreateMap<DeliveryType, CreateDeliveryTypeCommand>().ReverseMap();
            CreateMap<OrderStatus, CreateOrderStatusCommand>().ReverseMap();
            CreateMap<FileType, CreateFileTypeCommand>().ReverseMap();
            CreateMap<FileStatus, CreateFileStatusCommand>().ReverseMap();
            CreateMap<CreateCompanyCustomerCommand, Customer>().ReverseMap();
            CreateMap<CreatePersonCustomerCommand, Customer>().ReverseMap();
            CreateMap<CreateSupplierCommand, Supplier>().ReverseMap();
            CreateMap<CreateRepresentativeCommand, Representative>().ReverseMap();
            CreateMap<CreateAssignmentCommand, Assignment>().ReverseMap();
            CreateMap<CreateAddressCommand, Address>().ReverseMap();
            CreateMap<CreateBindingTypeCommand, BindingType>().ReverseMap();
            CreateMap<CreateOrderItemCommand, OrderItem>().ReverseMap();
            CreateMap<CreateSupplyCommand, Supply>().ReverseMap();
            CreateMap<CreateDeliveriesAddressesCommand, DeliveriesAddresses>().ReverseMap();
            CreateMap<CreateServiceNameCommand, ServiceName>().ReverseMap();
            CreateMap<CreateServiceCommand, Service>().ReverseMap();
            CreateMap<CreateColorCommand, Color>().ReverseMap();
            CreateMap<CreatePaperCommand, Paper>().ReverseMap();
            CreateMap<CreateFileCommand, Domain.Models.File>().ReverseMap();
            CreateMap<CreatePriceListCommand, PriceList>().ReverseMap();
            CreateMap<CreateValuationCommand, Valuation>().ReverseMap();
            CreateMap<CreateValuationPriceListCommand, ValuationPriceList>().ReverseMap();
            CreateMap<Worker, LoggedUserDTO>().ReverseMap();
        }
    }
}
