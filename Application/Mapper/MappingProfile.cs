using Application.Functions.Customer.Commands.CreateCompanyCustomerCommand;
using Application.Functions.Customer.Commands.CreatePersonCustomerCommand;
using Application.Functions.DeliveryType.Commands.CreateDeliveryTypeCommand;
using Application.Functions.FileStatus.Commands.CreateFileStatusCommand;
using Application.Functions.FileType.Commands.CreateFileTypeCommand;
using Application.Functions.OrderItemType.Commands.CreateOrderItemTypeCommand;
using Application.Functions.OrderStatus.Commands.CreateOrderStatusCommand;
using Application.Functions.RoleAssignment.Commands.CreateRoleAssignmentCommand;
using Application.Functions.Roles.Commands.CreateRole;
using Application.Functions.Supplier.Commands.CreateSupplierCommand;
using Application.Functions.SupplyItemType.Commands.CreateSupplyItemTypeCommand;
using Application.Functions.Workers;
using Application.Functions.Workers.Commands.CreateWorker;
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
            CreateMap<Worker, CreateWorkerCommand>().ReverseMap();
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
        }
    }
}
