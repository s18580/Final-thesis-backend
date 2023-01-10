using Domain.Models;
using Domain.Models.DictionaryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Application.Services
{
    public interface IApplicationContext
    {
        DatabaseFacade Database { get; }
        DbSet<Worksite> Worksites { get; set; }
        DbSet<Worker> Workers { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Supplier> Suppliers { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Representative> Representatives { get; set; }
        DbSet<Assignment> Assignments { get; set; }
        DbSet<OrderStatus> OrderStatuses { get; set; }
        DbSet<Supply> Supplies { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<SupplyItemType> SupplyItemTypes { get; set; }
        DbSet<DeliveriesAddresses> DeliveriesAddresses { get; set; }
        DbSet<Valuation> Valuations { get; set; }
        DbSet<BindingType> BindingTypes { get; set; }
        DbSet<DeliveryType> DeliveryTypes { get; set; }
        DbSet<OrderItemType> OrderItemTypes { get; set; }
        DbSet<Paper> Papers { get; set; }
        DbSet<Service> Services { get; set; }
        DbSet<ServiceName> ServiceNames { get; set; }
        DbSet<PriceList> PriceLists { get; set; }
        DbSet<ValuationPriceList> ValuationPriceLists { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<RoleAssignment> RoleAssignments { get; set; }
        Task<int> SaveChangesAsync();
    }
}