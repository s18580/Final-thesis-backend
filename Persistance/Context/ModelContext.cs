using Application.Services;
using Domain.Models;
using Domain.Models.DictionaryModels;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Context
{
    public class ModelContext : DbContext, IApplicationContext
    {
        public DbSet<Worksite> Worksites { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Representative> Representatives { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Domain.Models.File> Files { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<FileStatus> FileStatuses { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<SupplyItemType> SupplyItemTypes { get; set; }
        public DbSet<DeliveriesAddresses> DeliveriesAddresses { get; set; }
        public DbSet<Valuation> Valuations { get; set; }
        public DbSet<BindingType> BindingTypes { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }
        public DbSet<OrderItemType> OrderItemTypes { get; set; }
        public DbSet<Paper> Papers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceName> ServiceNames { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<ValuationPriceList> ValuationPriceLists { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAssignment> RoleAssignments { get; set; }

        public ModelContext() { }
        public ModelContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Worker>(opt =>
            {
                opt.HasKey(p => p.IdWorker);
                opt.Property(p => p.IdWorker).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(32)
                   .IsRequired();

                opt.Property(p => p.LastName)
                   .HasMaxLength(64)
                   .IsRequired();

                opt.Property(p => p.PhoneNumber)
                   .HasMaxLength(32);

                opt.Property(p => p.EmailAddres)
                   .HasMaxLength(255)
                   .IsRequired();

                opt.Property(p => p.RefreshToken)
                   .HasMaxLength(255);

                opt.HasOne(p => p.Worksite)
                   .WithMany(p => p.Workers)
                   .HasForeignKey(p => p.IdWorksite);

                opt.HasMany(p => p.Valuations)
                   .WithOne(p => p.Author)
                   .HasForeignKey(p => p.IdAuthor);

                opt.HasMany(p => p.Assignments)
                   .WithOne(p => p.Worker)
                   .HasForeignKey(p => p.IdWorker);

                opt.HasMany(p => p.Customers)
                   .WithOne(p => p.Worker)
                   .HasForeignKey(p => p.IdWorker);

                opt.HasMany(p => p.RoleAssignments)
                   .WithOne(p => p.Worker)
                   .HasForeignKey(p => p.IdWorker);
            });

            modelBuilder.Entity<Worksite>(opt =>
            {
                opt.HasKey(p => p.IdWorksite);
                opt.Property(p => p.IdWorksite).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(30)
                   .IsRequired();
            });

            modelBuilder.Entity<Customer>(opt =>
            {
                opt.HasKey(p => p.IdCustomer);
                opt.Property(p => p.IdCustomer).ValueGeneratedOnAdd();

                opt.Property(p => p.CompanyName)
                   .HasMaxLength(255);

                opt.Property(p => p.CompanyPhoneNumber)
                   .HasMaxLength(32);

                opt.Property(p => p.CompanyEmailAddress)
                   .HasMaxLength(255);

                opt.HasMany(p => p.Representatives)
                   .WithOne(p => p.Customer)
                   .HasForeignKey(p => p.IdCustomer);

            });

            modelBuilder.Entity<Supplier>(opt =>
            {
                opt.HasKey(p => p.IdSupplier);
                opt.Property(p => p.IdSupplier).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(255)
                   .IsRequired();

                opt.Property(p => p.Description)
                   .HasMaxLength(255);

                opt.Property(p => p.PhoneNumber)
                   .HasMaxLength(32);

                opt.Property(p => p.EmailAddress)
                   .HasMaxLength(255);

                opt.HasMany(p => p.Representatives)
                   .WithOne(p => p.Supplier)
                   .HasForeignKey(p => p.IdSupplier);
            });

            modelBuilder.Entity<Address>(opt =>
            {
                opt.HasKey(p => p.IdAddress);
                opt.Property(p => p.IdAddress).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(255)
                   .IsRequired();

                opt.Property(p => p.Country)
                   .HasMaxLength(30)
                   .IsRequired();

                opt.Property(p => p.City)
                   .HasMaxLength(50)
                   .IsRequired();

                opt.Property(p => p.StreetName)
                   .HasMaxLength(100)
                   .IsRequired();

                opt.Property(p => p.StreetNumber)
                   .HasMaxLength(10)
                   .IsRequired();

                opt.Property(p => p.ApartmentNumber)
                   .HasMaxLength(10);

                opt.HasOne(p => p.Customer)
                   .WithMany(p => p.Addresses)
                   .HasForeignKey(p => p.IdCustomer);

                opt.HasOne(p => p.Supplier)
                   .WithMany(p => p.Addresses)
                   .HasForeignKey(p => p.IdSupplier);

                opt.HasMany(p => p.DeliveriesAddresses)
                   .WithOne(p => p.Address)
                   .HasForeignKey(p => p.IdAddress);
            });

            modelBuilder.Entity<Representative>(opt =>
            {
                opt.HasKey(p => p.IdRepresentative);
                opt.Property(p => p.IdRepresentative).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(32)
                   .IsRequired();

                opt.Property(p => p.LastName)
                   .HasMaxLength(64)
                   .IsRequired();

                opt.Property(p => p.PhoneNumber)
                   .HasMaxLength(32);

                opt.Property(p => p.EmailAddress)
                   .HasMaxLength(255);
            });

            modelBuilder.Entity<Assignment>(opt =>
            {
                opt.HasKey(p => new { p.IdWorker, p.IdOrder });
            });

            modelBuilder.Entity<Order>(opt =>
            {
                opt.HasKey(p => p.IdOrder);
                opt.Property(p => p.IdOrder).ValueGeneratedOnAdd();

                opt.Property(p => p.Identifier)
                   .HasMaxLength(25)
                   .IsRequired();

                opt.Property(p => p.Name)
                   .HasMaxLength(255)
                   .IsRequired();

                opt.Property(p => p.Note)
                   .HasMaxLength(255);

                opt.HasOne(p => p.Status)
                   .WithMany(p => p.Orders)
                   .HasForeignKey(p => p.IdStatus);

                opt.HasMany(p => p.DeliveriesAddresses)
                   .WithOne(p => p.Order)
                   .HasForeignKey(p => p.IdOrder);

                opt.HasOne(p => p.Representative)
                   .WithMany(p => p.Orders)
                   .HasForeignKey(p => p.IdRepresentative);

                opt.HasMany(p => p.Assignments)
                   .WithOne(p => p.Order)
                   .HasForeignKey(p => p.IdOrder);

                opt.HasMany(p => p.OrderItems)
                   .WithOne(p => p.Order)
                   .HasForeignKey(p => p.IdOrder);

                opt.HasMany(p => p.Files)
                   .WithOne(p => p.Order)
                   .HasForeignKey(p => p.IdOrder);
            });

            modelBuilder.Entity<OrderStatus>(opt =>
            {
                opt.HasKey(p => p.IdStatus);
                opt.Property(p => p.IdStatus).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(30)
                   .IsRequired();
            });

            modelBuilder.Entity<Domain.Models.File>(opt =>
            {
                opt.HasKey(p => p.IdFile);
                opt.Property(p => p.IdFile).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(50)
                   .IsRequired();

                opt.HasOne(p => p.FileStatus)
                   .WithMany(p => p.Files)
                   .HasForeignKey(p => p.IdFileStatus);

                opt.HasOne(p => p.FileType)
                   .WithMany(p => p.Files)
                   .HasForeignKey(p => p.IdFileType);

            });

            modelBuilder.Entity<FileType>(opt =>
            {
                opt.HasKey(p => p.IdFileType);
                opt.Property(p => p.IdFileType).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(30)
                   .IsRequired();
            });

            modelBuilder.Entity<FileStatus>(opt =>
            {
                opt.HasKey(p => p.IdFileStatus);
                opt.Property(p => p.IdFileStatus).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(30)
                   .IsRequired();
            });

            modelBuilder.Entity<DeliveriesAddresses>(opt =>
            {
                opt.HasKey(p => p.IdDeliveriesAddresses);
                opt.Property(p => p.IdDeliveriesAddresses).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Supply>(opt =>
            {
                opt.HasKey(p => p.IdSupply);
                opt.Property(p => p.IdSupply).ValueGeneratedOnAdd();

                opt.Property(p => p.ItemDescription)
                   .HasMaxLength(255)
                   .IsRequired();

                opt.HasOne(p => p.SupplyItemType)
                   .WithMany(p => p.Supplies)
                   .HasForeignKey(p => p.IdSupplyItemType);

                opt.HasMany(p => p.DeliveriesAddresses)
                   .WithOne(p => p.Supply)
                   .HasForeignKey(p => p.IdSupply);

                opt.HasOne(p => p.OrderItem)
                   .WithMany(p => p.Supplies)
                   .HasForeignKey(p => p.IdOrderItem);

                opt.HasOne(p => p.Representative)
                   .WithMany(p => p.Supplies)
                   .HasForeignKey(p => p.IdRepresentative);
            });

            modelBuilder.Entity<SupplyItemType>(opt =>
            {
                opt.HasKey(p => p.IdSupplyItemType);
                opt.Property(p => p.IdSupplyItemType).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(30)
                   .IsRequired();
            });

            modelBuilder.Entity<OrderItem>(opt => {
                opt.HasKey(p => p.IdOrderItem);
                opt.Property(p => p.IdOrderItem).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(255)
                   .IsRequired();

                opt.Property(p => p.Comments)
                   .HasMaxLength(255);

                opt.Property(p => p.CoverFormat)
                   .HasMaxLength(100);

                opt.Property(p => p.InsideFormat)
                   .HasMaxLength(100)
                   .IsRequired();

                opt.HasMany(p => p.Files)
                   .WithOne(p => p.OrderItem)
                   .HasForeignKey(p => p.IdOrderItem);

                opt.HasOne(p => p.OrderItemType)
                   .WithMany(p => p.OrderItems)
                   .HasForeignKey(p => p.IdOrderItemType);

                opt.HasOne(p => p.DeliveryType)
                   .WithMany(p => p.OrderItems)
                   .HasForeignKey(p => p.IdDeliveryType);

                opt.HasOne(p => p.BindingType)
                   .WithMany(p => p.OrderItems)
                   .HasForeignKey(p => p.IdBindingType);

            });

            modelBuilder.Entity<DeliveryType>(opt =>
            {
                opt.HasKey(p => p.IdDeliveryType);
                opt.Property(p => p.IdDeliveryType).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(30)
                   .IsRequired();
            });

            modelBuilder.Entity<OrderItemType>(opt =>
            {
                opt.HasKey(p => p.IdOrderItemType);
                opt.Property(p => p.IdOrderItemType).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(30)
                   .IsRequired();
            });

            modelBuilder.Entity<Color>(opt =>
            {
                opt.HasKey(p => p.IdColor);
                opt.Property(p => p.IdColor).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(10)
                   .IsRequired();

                opt.HasOne(p => p.Valuation)
                   .WithMany(p => p.Colors)
                   .HasForeignKey(p => p.IdColor);

                opt.HasOne(p => p.OrderItem)
                   .WithMany(p => p.Colors)
                   .HasForeignKey(p => p.IdColor);
            });

            modelBuilder.Entity<BindingType>(opt =>
            {
                opt.HasKey(p => p.IdBindingType);
                opt.Property(p => p.IdBindingType).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(30)
                   .IsRequired();
            });

            modelBuilder.Entity<ServiceName>(opt =>
            {
                opt.HasKey(p => p.IdServiceName);
                opt.Property(p => p.IdServiceName).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(30)
                   .IsRequired();
            });

            modelBuilder.Entity<Valuation>(opt =>
            {
                opt.HasKey(p => p.IdValuation);
                opt.Property(p => p.IdValuation).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(255)
                   .IsRequired();

                opt.Property(p => p.InsideFormat)
                   .HasMaxLength(100)
                   .IsRequired();

                opt.Property(p => p.InsideSheetFormat)
                   .HasMaxLength(100)
                   .IsRequired();

                opt.Property(p => p.CoverFormat)
                   .HasMaxLength(100);

                opt.Property(p => p.CoverSheetFormat)
                   .HasMaxLength(100);

                opt.HasMany(p => p.Files)
                   .WithOne(p => p.Valuation)
                   .HasForeignKey(p => p.IdValuation);

                opt.HasOne(p => p.BindingType)
                   .WithMany(p => p.Valuations)
                   .HasForeignKey(p => p.IdBindingType);

                opt.HasMany(p => p.PriceListPrices)
                   .WithOne(p => p.Valuation)
                   .HasForeignKey(p => p.IdPriceList);
            });

            modelBuilder.Entity<Paper>(opt =>
            {
                opt.HasKey(p => p.IdPaper);
                opt.Property(p => p.IdPaper).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(255)
                   .IsRequired();

                opt.Property(p => p.Kind)
                   .HasMaxLength(50);

                opt.Property(p => p.SheetFormat)
                   .HasMaxLength(100)
                   .IsRequired();

                opt.HasOne(p => p.OrderItem)
                   .WithMany(p => p.Papers)
                   .HasForeignKey(p => p.IdPaper);

                opt.HasOne(p => p.Valuation)
                   .WithMany(p => p.Papers)
                   .HasForeignKey(p => p.IdPaper);
            });

            modelBuilder.Entity<Service>(opt =>
            {
                opt.HasKey(p => p.IdService);
                opt.Property(p => p.IdService).ValueGeneratedOnAdd();

                opt.HasOne(p => p.ServiceName)
                   .WithMany(p => p.Services)
                   .HasForeignKey(p => p.IdServiceName);

                opt.HasOne(p => p.OrderItem)
                   .WithMany(p => p.Services)
                   .HasForeignKey(p => p.IdService);

                opt.HasOne(p => p.Valuation)
                   .WithMany(p => p.Services)
                   .HasForeignKey(p => p.IdService);
            });

            modelBuilder.Entity<PriceList>(opt =>
            {
                opt.HasKey(p => p.IdPriceList);
                opt.Property(p => p.IdPriceList).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(30)
                   .IsRequired();

                opt.HasMany(p => p.ValuationPriceLists)
                   .WithOne(p => p.PriceList)
                   .HasForeignKey(p => p.IdPriceList);
            });

            modelBuilder.Entity<ValuationPriceList>(opt =>
            {
                opt.HasKey(p => new { p.IdValuation, p.IdPriceList });
            });

            modelBuilder.Entity<Role>(opt =>
            {
                opt.HasKey(p => p.IdRole);
                opt.Property(p => p.IdRole).ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                   .HasMaxLength(30);

                opt.HasMany(p => p.RoleAssignments)
                   .WithOne(p => p.Role)
                   .HasForeignKey(p => p.IdRole);
            });

            modelBuilder.Entity<RoleAssignment>(opt =>
            {
                opt.HasKey(p => new { p.IdWorker, p.IdRole });
            });
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
