using Application.Functions.Address.Commands.CreateAddressCommand;
using Application.Functions.Assignment.Commands.CreateAssignmentCommand;
using Application.Functions.BindingType.Commands.CreateBindingTypeCommand;
using Application.Functions.DeliveriesAddresses.Commands.CreateDeliveriesAddressesCommand;
using Application.Functions.DeliveryType.Commands.CreateDeliveryTypeCommand;
using Application.Functions.OrderItem.Commands.CreateOrderItemCommand;
using Application.Functions.OrderItemType.Commands.CreateOrderItemTypeCommand;
using Application.Functions.OrderStatus.Commands.CreateOrderStatusCommand;
using Application.Functions.PriceList.Commands.CreatePriceListCommand;
using Application.Functions.Representative.Commands.CreateRepresentativeCommand;
using Application.Functions.ServiceName.Commands.CreateServiceNameCommand;
using Application.Functions.SupplyItemType.Commands.CreateSupplyItemTypeCommand;
using Application.Functions.Valuation.Commands.CreateValuationCommand;
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
            CreateMap<Worker, WorkerDTO>().ReverseMap();
            CreateMap<SupplyItemType, CreateSupplyItemTypeCommand>().ReverseMap();
            CreateMap<OrderItemType, CreateOrderItemTypeCommand>().ReverseMap();
            CreateMap<DeliveryType, CreateDeliveryTypeCommand>().ReverseMap();
            CreateMap<OrderStatus, CreateOrderStatusCommand>().ReverseMap();
            CreateMap<CreateRepresentativeCommand, Representative>().ReverseMap();
            CreateMap<CreateAssignmentCommand, Assignment>().ReverseMap();
            CreateMap<CreateAddressCommand, Address>().ReverseMap();
            CreateMap<CreateBindingTypeCommand, BindingType>().ReverseMap();
            CreateMap<CreateOrderItemCommand, OrderItem>().ReverseMap();
            CreateMap<CreateDeliveriesAddressesCommand, DeliveriesAddresses>().ReverseMap();
            CreateMap<CreateServiceNameCommand, ServiceName>().ReverseMap();
            CreateMap<CreatePriceListCommand, PriceList>().ReverseMap();
            CreateMap<CreateValuationCommand, Valuation>().ReverseMap();
        }
    }
}
