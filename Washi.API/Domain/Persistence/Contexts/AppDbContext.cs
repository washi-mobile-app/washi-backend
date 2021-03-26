using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;
using Washi.API.Extensions;

namespace Washi.API.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<UserPaymentMethod> UserPaymentMethods { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ServiceMaterial> ServiceMaterials { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryCurrency> CountryCurrencies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<LaundryServiceMaterial> LaundryServiceMaterials { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //User Entity
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>()
                .HasOne(p => p.UserProfile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);
            builder.Entity<User>().HasKey(p => p.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.Email).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(50);
           
            builder.Entity<User>().HasData
                (
                    new User { Id = 1, Email = "felipedota2@gmail.com", Password = "slark" },
                    new User { Id = 2, Email = "xavistian@gmail.com", Password = "tiaaaaaaaan" },
                    new User { Id = 3, Email = "bergazo@gmail.com", Password = "mdemarcio" },
                    new User { Id = 4, Email = "citrionix4004@gmail.com", Password = "william" },
                    new User { Id = 5, Email = "navY@gmail.com", Password = "aasuuu" },
                    new User { Id = 6, Email = "carcazas@gmail.com", Password = "ontamisd" }
                );

            //UserProfile Entity

            builder.Entity<UserProfile>().ToTable("UserProfiles");
            builder.Entity<UserProfile>().HasKey(p => p.Id);
            builder.Entity<UserProfile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<UserProfile>().Property(p => p.UserId);
            builder.Entity<UserProfile>().Property(p => p.FirstName);
            builder.Entity<UserProfile>().Property(p => p.LastName);
            builder.Entity<UserProfile>().Property(p => p.DateOfBirth);
            builder.Entity<UserProfile>().Property(p => p.Sex);
            builder.Entity<UserProfile>().Property(p => p.DateOfRegistry);
            builder.Entity<UserProfile>().Property(p => p.Address).IsRequired();
            builder.Entity<UserProfile>().Property(p => p.PhoneNumber).IsRequired();
            builder.Entity<UserProfile>().Property(p => p.CorporationName);
            builder.Entity<UserProfile>().Property(p => p.UserType).IsRequired();
            builder.Entity<UserProfile>().Property(p => p.ImageUrl);
            builder.Entity<UserProfile>().Property(p => p.DistrictId);
            builder.Entity<UserProfile>().HasData
                (
                    new UserProfile { Id = 1, UserId = 1, FirstName = "Felipe", LastName = "Kacomt", Sex = ESex.Female, Address = "Av. Chiclayo 343", PhoneNumber = 987654321, UserType = EUserType.Washer, DateOfBirth = new DateTime(1998, 01, 23), DateOfRegistry = DateTime.Now, DistrictId = 2, ImageUrl = null },
                    new UserProfile { Id = 2, UserId = 2, CorporationName = "El Lavadín", Address = "Watchflowers 451", PhoneNumber = 999888777, UserType = EUserType.Laundry, DateOfBirth = new DateTime(1900, 01, 01), DateOfRegistry = DateTime.Now, DistrictId = 1, ImageUrl = null },
                    new UserProfile { Id = 3, UserId = 3, FirstName = "Marcio", LastName = "Bergazo", Sex = ESex.Female, Address = "Magmalena 234", PhoneNumber = 987654321, UserType = EUserType.Washer, DateOfBirth = new DateTime(1998, 04, 26), DateOfRegistry = DateTime.Now, DistrictId = 3, ImageUrl = null },
                    new UserProfile { Id = 4, UserId = 4, CorporationName = "Don Lavadón", Address = "Chiclayork 543", PhoneNumber = 999888777, UserType = EUserType.Laundry, DateOfBirth = new DateTime(1900, 01, 01), DateOfRegistry = DateTime.Now, DistrictId = 4, ImageUrl = null },
                    new UserProfile { Id = 5, UserId = 5, FirstName = "Yivan", LastName = "Pérez", Sex = ESex.Female, Address = "Jesus María 854", PhoneNumber = 987654321, UserType = EUserType.Washer, DateOfBirth = new DateTime(1998, 07, 13), DateOfRegistry = DateTime.Now, DistrictId = 5, ImageUrl = null },
                    new UserProfile { Id = 6, UserId = 6, CorporationName = "Gianluca Lavadula", Address = "La Rossonera 666", PhoneNumber = 999888777, UserType = EUserType.Laundry, DateOfBirth = new DateTime(1900, 01, 01), DateOfRegistry = DateTime.Now, DistrictId = 1, ImageUrl = null }

                );
            
            // PaymentMethod Entity
            builder.Entity<PaymentMethod>().ToTable("PaymentMethods");
            builder.Entity<PaymentMethod>().HasKey(p => p.Id);
            builder.Entity<PaymentMethod>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PaymentMethod>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<PaymentMethod>().HasData
                (
                    new PaymentMethod { Id = 1, Name = "Tarjeta de regalo"},
                    new PaymentMethod { Id = 2, Name = "Tarjeta Coney Park" },
                    new PaymentMethod { Id = 3, Name = "Tarjeta BCP" }
                );

            // UserPaymentMethod Entity
            builder.Entity<UserPaymentMethod>().ToTable("UserPaymentMethods");
            builder.Entity<UserPaymentMethod>()
                .HasKey(p => new { p.UserId, p.PaymentMethodId });

            builder.Entity<UserPaymentMethod>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserPaymentMethods)
                .HasForeignKey(p => p.UserId);

            builder.Entity<UserPaymentMethod>()
                .HasOne(p => p.PaymentMethod)
                .WithMany(p => p.UserPaymentMethods)
                .HasForeignKey(p => p.PaymentMethodId);

            builder.Entity<UserPaymentMethod>().HasData
                (
                new UserPaymentMethod { UserId = 1, PaymentMethodId = 1 },
                new UserPaymentMethod { UserId = 2, PaymentMethodId = 2 },
                new UserPaymentMethod { UserId = 3, PaymentMethodId = 3 },
                new UserPaymentMethod { UserId = 4, PaymentMethodId = 3 },
                new UserPaymentMethod { UserId = 5, PaymentMethodId = 2 }
                );

            // Subscription Entity
            builder.Entity<Subscription>().ToTable("Subscriptions");
            builder.Entity<Subscription>().HasKey(p => p.Id);
            builder.Entity<Subscription>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Subscription>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Subscription>().Property(p => p.Price).IsRequired();
            builder.Entity<Subscription>().Property(p => p.DurationInDays).IsRequired();
            builder.Entity<Subscription>().HasData
                (
                    new Subscription { Id = 1, Name = "WasherPremium 1 mes", Price = Convert.ToDecimal(15.00), DurationInDays = 30 },
                    new Subscription { Id = 2, Name = "WasherPremium 3 meses", Price = Convert.ToDecimal(40.00), DurationInDays = 90 },
                    new Subscription { Id = 3, Name = "LaundryPremium 1 mes", Price = Convert.ToDecimal(100.00), DurationInDays = 30 },
                    new Subscription { Id = 4, Name = "LaundryPremium 3 meses", Price = Convert.ToDecimal(280.00), DurationInDays = 90 }

                );

            //UserSubscription Entity
            builder.Entity<UserSubscription>().ToTable("UserSubscriptions");
            builder.Entity<UserSubscription>()
                .HasKey(p => new { p.UserId, p.SubscriptionId });

            builder.Entity<UserSubscription>()
                .HasOne(p => p.User)
                .WithMany(p => p.UserSubscriptions)
                .HasForeignKey(p => p.UserId);

            builder.Entity<UserSubscription>()
                .HasOne(p => p.Subscription)
                .WithMany(p => p.UserSubscriptions)
                .HasForeignKey(p => p.SubscriptionId);
            builder.Entity<UserSubscription>().HasData
                (
                new UserSubscription { UserId = 1, SubscriptionId = 1, InitialDate = DateTime.Now, EndingDate = DateTime.Now.AddMonths(1)},
                new UserSubscription { UserId = 2, SubscriptionId = 3, InitialDate = DateTime.Now, EndingDate = DateTime.Now.AddMonths(1) },
                new UserSubscription { UserId = 3, SubscriptionId = 2, InitialDate = DateTime.Now, EndingDate = DateTime.Now.AddMonths(3) },
                new UserSubscription { UserId = 4, SubscriptionId = 4, InitialDate = DateTime.Now, EndingDate = DateTime.Now.AddMonths(3) },
                new UserSubscription { UserId = 5, SubscriptionId = 1, InitialDate = DateTime.Now, EndingDate = DateTime.Now.AddMonths(1) }
                );

            // Service Entity
            builder.Entity<Service>().ToTable("Services");
            builder.Entity<Service>().HasKey(p => p.Id);
            builder.Entity<Service>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Service>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Service>().HasData
                (
                    new Service { Id = 1, Name = "Lavado al agua" },
                    new Service { Id = 2, Name = "Lavado al seco" },
                    new Service { Id = 3, Name = "Lavado a mano" },
                    new Service { Id = 4, Name = "Planchado" }
                );

            //Material Entity
            builder.Entity<Material>().ToTable("Materials");
            builder.Entity<Material>().HasKey(p => p.Id);
            builder.Entity<Material>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Material>().Property(p => p.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Material>().HasData
                (
                    new Material { Id = 1, Name = "Algodón"},
                    new Material { Id = 2, Name = "Lino" },
                    new Material { Id = 3, Name = "Poliéster" },
                    new Material { Id = 4, Name = "Lana"},
                    new Material { Id = 5, Name = "Seda" },
                    new Material { Id = 6, Name = "Nylon" },
                    new Material { Id = 7, Name = "Licra" }
                );
            //ServiceMaterial Entity
            builder.Entity<ServiceMaterial>().ToTable("ServiceMaterials");
            builder.Entity<ServiceMaterial>()
                .HasKey(sm => sm.Id );
            builder.Entity<ServiceMaterial>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<ServiceMaterial>()
                .HasOne(sm => sm.Service)
                .WithMany(sm => sm.ServiceMaterials)
                .HasForeignKey(sm => sm.ServiceId);

            builder.Entity<ServiceMaterial>()
                .HasOne(sm => sm.Material)
                .WithMany(sm => sm.ServiceMaterials)
                .HasForeignKey(sm => sm.MaterialId);
            builder.Entity<ServiceMaterial>().HasData
                (
                    new ServiceMaterial { Id = 1, ServiceId = 1, MaterialId = 1 },
                    new ServiceMaterial { Id = 2, ServiceId = 1, MaterialId = 3 },
                    new ServiceMaterial { Id = 3, ServiceId = 1, MaterialId = 4 },
                    new ServiceMaterial { Id = 4, ServiceId = 1, MaterialId = 6 },
                    new ServiceMaterial { Id = 5, ServiceId = 1, MaterialId = 7 },
                    new ServiceMaterial { Id = 6, ServiceId = 2, MaterialId = 1 },
                    new ServiceMaterial { Id = 7, ServiceId = 2, MaterialId = 2 },
                    new ServiceMaterial { Id = 8, ServiceId = 2, MaterialId = 4 },
                    new ServiceMaterial { Id = 9, ServiceId = 2, MaterialId = 5 },
                    new ServiceMaterial { Id = 10, ServiceId = 3, MaterialId = 5 },
                    new ServiceMaterial { Id = 11, ServiceId = 3, MaterialId = 4 },
                    new ServiceMaterial { Id = 12, ServiceId = 3, MaterialId = 1 },
                    new ServiceMaterial { Id = 13, ServiceId = 3, MaterialId = 3 },
                    new ServiceMaterial { Id = 14, ServiceId = 4, MaterialId = 1 },
                    new ServiceMaterial { Id = 15, ServiceId = 4, MaterialId = 3 },
                    new ServiceMaterial { Id = 16, ServiceId = 4, MaterialId = 5 },
                    new ServiceMaterial { Id = 17, ServiceId = 4, MaterialId = 7 },
                    new ServiceMaterial { Id = 18, ServiceId = 4, MaterialId = 2 }
                );
            //LaundryServiceMaterial Entity
            builder.Entity<LaundryServiceMaterial>().ToTable("LaundrySMs");
            builder.Entity<LaundryServiceMaterial>().HasKey(lsm => lsm.Id);
            builder.Entity<LaundryServiceMaterial>().Property(lsm => lsm.Id).IsRequired().ValueGeneratedOnAdd();

            builder.Entity<LaundryServiceMaterial>()
                .HasOne(lsm => lsm.Laundry)
                .WithMany(lsm => lsm.LaundryServiceMaterials)
                .HasForeignKey(lsm => lsm.LaundryId);

            builder.Entity<LaundryServiceMaterial>()
                .HasOne(lsm => lsm.ServiceMaterial)
                .WithMany(lsm => lsm.LaundryServiceMaterials)
                .HasForeignKey(lsm => lsm.ServiceMaterialId);

            builder.Entity<LaundryServiceMaterial>().Property(lsm => lsm.Price).IsRequired();
            builder.Entity<LaundryServiceMaterial>().Property(lsm => lsm.Description).IsRequired().HasMaxLength(150);
            builder.Entity<LaundryServiceMaterial>().Property(lsm => lsm.EstimatedDeliveryTimeInDays);
            builder.Entity<LaundryServiceMaterial>().Property(lsm => lsm.Rating);
            builder.Entity<LaundryServiceMaterial>().HasData
               (
                    new LaundryServiceMaterial { Id = 1, LaundryId = 2, ServiceMaterialId = 1, Price = Convert.ToDecimal(15.00), Description = "Lavado al agua común de nuestros especialistas en máquinas de lavado.", EstimatedDeliveryTimeInDays = 1 },
                    new LaundryServiceMaterial { Id = 2, LaundryId = 2, ServiceMaterialId = 2, Price = Convert.ToDecimal(10.00), Description = "Nuestro lavado al agua de poliéster es de los mejores del mercado.", EstimatedDeliveryTimeInDays = 2 },
                    new LaundryServiceMaterial { Id = 3, LaundryId = 2, ServiceMaterialId = 3, Price = Convert.ToDecimal(12.00), Description = "Cuidaremos de tu ropa de lana y quedará como nueva.", EstimatedDeliveryTimeInDays = 1 },
                    new LaundryServiceMaterial { Id = 4, LaundryId = 2, ServiceMaterialId = 4, Price = Convert.ToDecimal(17.00), Description = "Sabemos que tus prendas de nylon son muy importantes, por lo que las lavaremos con muchísimo cuidado.", EstimatedDeliveryTimeInDays = 1 },
                    new LaundryServiceMaterial { Id = 5, LaundryId = 2, ServiceMaterialId = 5, Price = Convert.ToDecimal(12.00), Description = "Las prendas de licra son caras y delicadas, dejanos el trabajo de lavarlas a nosotros.", EstimatedDeliveryTimeInDays = 3 },
                    new LaundryServiceMaterial { Id = 6, LaundryId = 2, ServiceMaterialId = 6, Price = Convert.ToDecimal(13.00), Description = "Tus prendas de algodón estarán en las manos de expertos en lavado al seco.", EstimatedDeliveryTimeInDays = 1 },
                    new LaundryServiceMaterial { Id = 7, LaundryId = 2, ServiceMaterialId = 7, Price = Convert.ToDecimal(11.00), Description = "Tus sofisticadas prendas de lino serán lavadas de la mejor forma posible.", EstimatedDeliveryTimeInDays = 2 },
                    new LaundryServiceMaterial { Id = 8, LaundryId = 2, ServiceMaterialId = 8, Price = Convert.ToDecimal(15.00), Description = "La lana puede ser difícil de lavar, déjanos ese trabajo a nosotros!", EstimatedDeliveryTimeInDays = 1 },
                    new LaundryServiceMaterial { Id = 9, LaundryId = 2, ServiceMaterialId = 9, Price = Convert.ToDecimal(18.00), Description = "Las prendas de seda son lujosas y pueden ser dañadas. Déjanos lavarlas!", EstimatedDeliveryTimeInDays = 1 },

                    new LaundryServiceMaterial { Id = 10, LaundryId = 4, ServiceMaterialId = 7, Price = Convert.ToDecimal(10.00), Description = "Las prendas de lino son muy difíciles de lavar, te ayudamos!", EstimatedDeliveryTimeInDays = 3 },
                    new LaundryServiceMaterial { Id = 11, LaundryId = 4, ServiceMaterialId = 8, Price = Convert.ToDecimal(9.00), Description = "Prendas de lana? No te hagas bolas! Déjanos lavarlas a nosotros!", EstimatedDeliveryTimeInDays = 1 },
                    new LaundryServiceMaterial { Id = 12, LaundryId = 4, ServiceMaterialId = 9, Price = Convert.ToDecimal(15.00), Description = "Prendas de seda? No te hagas bolas! Déjanos lavarlas a nosotros!", EstimatedDeliveryTimeInDays = 2 },
                    new LaundryServiceMaterial { Id = 13, LaundryId = 4, ServiceMaterialId = 10, Price = Convert.ToDecimal(17.00), Description = "Lavar a mano tus prendas de seda es la mejor forma de mantenerlas como nuevas.", EstimatedDeliveryTimeInDays = 1 },
                    new LaundryServiceMaterial { Id = 14, LaundryId = 4, ServiceMaterialId = 11, Price = Convert.ToDecimal(12.00), Description = "El lavado a mano de lana es una opción bastante factible y económica.", EstimatedDeliveryTimeInDays = 1 },
                    new LaundryServiceMaterial { Id = 15, LaundryId = 4, ServiceMaterialId = 12, Price = Convert.ToDecimal(13.00), Description = "Lavado a la antigua! Siempre será mejor!", EstimatedDeliveryTimeInDays = 3 },
                    new LaundryServiceMaterial { Id = 16, LaundryId = 4, ServiceMaterialId = 13, Price = Convert.ToDecimal(11.00), Description = "El poliéster es uno de los materiales más adecuados para el lavado a mano.", EstimatedDeliveryTimeInDays = 1 },
                    new LaundryServiceMaterial { Id = 17, LaundryId = 4, ServiceMaterialId = 14, Price = Convert.ToDecimal(10.00), Description = "Plancharemos tus prendas de algodón tan bien que quedarán como nuevas!", EstimatedDeliveryTimeInDays = 2 },
                    new LaundryServiceMaterial { Id = 18, LaundryId = 4, ServiceMaterialId = 15, Price = Convert.ToDecimal(14.00), Description = "Poliéster? No es problema para nosotros! Podemos plancharlo!", EstimatedDeliveryTimeInDays = 1 },

                    new LaundryServiceMaterial { Id = 19, LaundryId = 6, ServiceMaterialId = 13, Price = Convert.ToDecimal(13.00), Description = "Lavado a mano de poliéster hecho por expertos.", EstimatedDeliveryTimeInDays = 1 },
                    new LaundryServiceMaterial { Id = 20, LaundryId = 6, ServiceMaterialId = 14, Price = Convert.ToDecimal(15.00), Description = "Planchado simple de prendas de algodón hecho por expertos.", EstimatedDeliveryTimeInDays = 3 },
                    new LaundryServiceMaterial { Id = 21, LaundryId = 6, ServiceMaterialId = 15, Price = Convert.ToDecimal(17.00), Description = "El poliéster es fácil de planchar para nosotros, confíanos tus prendas!", EstimatedDeliveryTimeInDays = 1 },
                    new LaundryServiceMaterial { Id = 22, LaundryId = 6, ServiceMaterialId = 16, Price = Convert.ToDecimal(21.00), Description = "Puede que sea imposible para ti planchar prendas de seda. Para nosotros no.", EstimatedDeliveryTimeInDays = 2 },
                    new LaundryServiceMaterial { Id = 23, LaundryId = 6, ServiceMaterialId = 17, Price = Convert.ToDecimal(21.00), Description = "Prendas de licra? Nosotros podemos plancharlas!", EstimatedDeliveryTimeInDays = 1 },
                    new LaundryServiceMaterial { Id = 24, LaundryId = 6, ServiceMaterialId = 18, Price = Convert.ToDecimal(20.00), Description = "Las prendas de lino son caras y delicadas, dejanos plancharlas por ti.", EstimatedDeliveryTimeInDays = 1 },
                    new LaundryServiceMaterial { Id = 25, LaundryId = 6, ServiceMaterialId = 1, Price = Convert.ToDecimal(12.00), Description = "Planchamos tus prendas de algodón a bajo costo!", EstimatedDeliveryTimeInDays = 3 },
                    new LaundryServiceMaterial { Id = 26, LaundryId = 6, ServiceMaterialId = 2, Price = Convert.ToDecimal(14.00), Description = "Lavado de poliéster en manos de expertos en lavado al agua.", EstimatedDeliveryTimeInDays = 1 },
                    new LaundryServiceMaterial { Id = 27, LaundryId = 6, ServiceMaterialId = 3, Price = Convert.ToDecimal(13.00), Description = "Lavado de lana en manos de expertos en lavado al agua.", EstimatedDeliveryTimeInDays = 1 }
               );
    
            //Currency Entity
            builder.Entity<Currency>().ToTable("Currencies");
            builder.Entity<Currency>().HasKey(c => c.Id);
            builder.Entity<Currency>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Currency>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Currency>().Property(c => c.Symbol).IsRequired().HasMaxLength(5);
            builder.Entity<Currency>().HasData
                (
                    new Currency { Id = 2, Name = "Dólar Estadounidense", Symbol = "$" },
                    new Currency { Id = 1, Name = "Sol", Symbol = "S/" },
                    new Currency { Id = 3, Name = "Euro", Symbol = "€" }
                );

            //CountryCurrency
            builder.Entity<CountryCurrency>().ToTable("CountryCurrencies");
            builder.Entity<CountryCurrency>().HasKey(cc => cc.Id);
            builder.Entity<CountryCurrency>().Property(cc => cc.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<CountryCurrency>().HasOne(cc => cc.Country).WithMany(c => c.CountryCurrencies).HasForeignKey(cc => cc.CountryId);
            builder.Entity<CountryCurrency>().HasOne(cc => cc.Currency).WithMany(c => c.CountryCurrencies).HasForeignKey(cc => cc.CurrencyId);
            builder.Entity<CountryCurrency>().HasData
                (
                    new CountryCurrency { Id = 1, CountryId = 1, CurrencyId = 1 },
                    new CountryCurrency { Id = 2, CountryId = 1, CurrencyId = 2 },
                    new CountryCurrency { Id = 3, CountryId = 1, CurrencyId = 3 },
                    new CountryCurrency { Id = 4, CountryId = 2, CurrencyId = 2 }
                );
            //Country Entity
            builder.Entity<Country>().ToTable("Countries");
            builder.Entity<Country>().HasKey(c => c.Id);
            builder.Entity<Country>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Country>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Entity<Country>().HasMany(c => c.Departments).WithOne(d => d.Country).HasForeignKey(d => d.CountryId);
            builder.Entity<Country>().HasData
                (
                    new Country { Id = 1, Name = "Perú" },
                    new Country { Id = 2, Name = "Estados Unidos" }
                );
            //Department Entity
            builder.Entity<Department>().ToTable("Departments");
            builder.Entity<Department>().HasKey(c => c.Id);
            builder.Entity<Department>().Property(c => c.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Entity<Department>().Property(c => c.Name)
                .IsRequired();
            builder.Entity<Department>().HasMany(p => p.Districts)
                                        .WithOne(p => p.Department)
                                        .HasForeignKey(p => p.DepartmentId);
            builder.Entity<Department>().HasData
                (
                    new Department { Id = 1, Name = "Lima", CountryId = 1 },
                    new Department { Id = 2, Name = "La Libertad", CountryId = 1 }
                );
            //District Entity
            builder.Entity<District>().ToTable("Districts");
            builder.Entity<District>().HasKey(d => d.Id);
            builder.Entity<District>().Property(d => d.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Entity<District>().Property(d => d.Name)
                .IsRequired();
            builder.Entity<District>().HasMany(p => p.UserProfiles)
                                      .WithOne(p => p.District)
                                      .HasForeignKey(p => p.DistrictId);
            builder.Entity<District>().HasData
                (
                    new District { Id = 1, Name = "Miraflores", DepartmentId = 1 },
                    new District { Id = 2, Name = "Barranco", DepartmentId = 1 },
                    new District { Id = 3, Name = "San Isidro", DepartmentId = 1 },
                    new District { Id = 4, Name = "Chaclacayo", DepartmentId = 1 },
                    new District { Id = 5, Name = "Chiclayo", DepartmentId = 2 }
                );
            //Order Entity
            builder.Entity<Order>().ToTable("Orders");
            builder.Entity<Order>().HasKey(o => o.Id);
            builder.Entity<Order>().Property(o => o.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Order>().Property(o => o.DeliveryAddress).IsRequired();
            builder.Entity<Order>().HasOne(o => o.User).WithMany(o => o.Orders).HasForeignKey(o => o.UserId);
            builder.Entity<Order>().HasOne(o => o.OrderStatus).WithMany(o => o.Orders).HasForeignKey(o => o.OrderStatusId);
            builder.Entity<Order>().HasData
                (
                    new Order { Id = 1, Date = DateTime.Now, DeliveryAddress = "Ca. Manco Capac 121, dpto. 21", OrderAmount = 42.50, OrderStatusId = 1, UserId = 1, DeliveryDate = DateTime.Now.AddDays(2) },
                    new Order { Id = 2, Date = DateTime.Now, DeliveryAddress = "Av. 28 de Julio 230, dpto. 802", OrderAmount = 130.30, OrderStatusId = 2, UserId = 2, DeliveryDate = DateTime.Now.AddDays(1) },
                    new Order { Id = 3, Date = DateTime.Now, DeliveryAddress = "Av. Larco 202", OrderAmount = 320.50, OrderStatusId = 3, UserId = 3, DeliveryDate = DateTime.Now.AddDays(3) }
                );
            //OrderStatus Entity
            builder.Entity<OrderStatus>().ToTable("OrderStatuses");
            builder.Entity<OrderStatus>().HasKey(os => os.Id);
            builder.Entity<OrderStatus>().Property(os => os.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<OrderStatus>().Property(os => os.Name).IsRequired();
            builder.Entity<OrderStatus>().HasData
                (
                    new OrderStatus { Id = 1, Name = "Por comenzar" },
                    new OrderStatus { Id = 2, Name = "En proceso" },
                    new OrderStatus { Id = 3, Name = "A punto de terminar" },
                    new OrderStatus { Id = 4, Name = "Lavado finalizado" },
                    new OrderStatus { Id = 5, Name = "Siendo entregada" },
                    new OrderStatus { Id = 6, Name = "Entregada" }
                );
            //OrderDetail Entity
            builder.Entity<OrderDetail>().ToTable("OrderDetails");
            builder.Entity<OrderDetail>().HasKey(od => od.Id);
            builder.Entity<OrderDetail>().HasOne(od => od.Order).WithMany(o => o.OrderDetails).HasForeignKey(o => o.OrderId);
            builder.Entity<OrderDetail>().HasOne(od => od.LaundryServiceMaterial).WithMany(lsm => lsm.OrderDetails).HasForeignKey(od => od.LaundryServiceMaterialId);
            builder.Entity<OrderDetail>().Property(od => od.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<OrderDetail>().HasData
                (
                    new OrderDetail { Id = 1, OrderId = 1, LaundryServiceMaterialId = 1, Rating = 5 },
                    new OrderDetail { Id = 2, OrderId = 1, LaundryServiceMaterialId = 2, Rating = 3 },
                    new OrderDetail { Id = 3, OrderId = 2, LaundryServiceMaterialId = 1, Rating = 4 }
                );
            //Promotion Entity
            builder.Entity<Promotion>().ToTable("Promotions");
            builder.Entity<Promotion>().HasKey(p => p.Id);
            builder.Entity<Promotion>().Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();
            builder.Entity<Promotion>()
                .HasOne(p => p.LaundryServiceMaterial)
                .WithMany(p => p.Promotions)
                .HasForeignKey(p => p.LaundryServiceMaterialId);
            builder.Entity<Promotion>().Property(p => p.DiscountPercentage).IsRequired();
            builder.Entity<Promotion>().Property(p => p.InitialDate);
            builder.Entity<Promotion>().Property(p => p.EndingDate).IsRequired();
            builder.Entity<Promotion>().HasData
                (
                    new Promotion { Id = 1, LaundryServiceMaterialId = 1, InitialDate = DateTime.Now, EndingDate = DateTime.Now.AddMonths(1), DiscountPercentage = 25 },
                    new Promotion { Id = 2, LaundryServiceMaterialId = 4, InitialDate = DateTime.Now, EndingDate = DateTime.Now.AddMonths(2), DiscountPercentage = 20 },
                    new Promotion { Id = 3, LaundryServiceMaterialId = 8, InitialDate = DateTime.Now, EndingDate = DateTime.Now.AddMonths(1), DiscountPercentage = 15 },
                    new Promotion { Id = 4, LaundryServiceMaterialId = 16, InitialDate = DateTime.Now, EndingDate = DateTime.Now.AddMonths(1), DiscountPercentage = 10 },
                    new Promotion { Id = 5, LaundryServiceMaterialId = 19, InitialDate = DateTime.Now, EndingDate = DateTime.Now.AddMonths(2), DiscountPercentage = 30 },
                    new Promotion { Id = 6, LaundryServiceMaterialId = 21, InitialDate = DateTime.Now, EndingDate = DateTime.Now.AddMonths(1), DiscountPercentage = 15 }
                );

            ApplySnakeCaseNamingConvention(builder);
        }

        private void ApplySnakeCaseNamingConvention(ModelBuilder builder)
        {
            foreach (var entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.GetTableName().ToSnakeCase());
                foreach (var property in entity.GetProperties())
                    property.SetColumnName(property.GetColumnName().ToSnakeCase());
                foreach (var key in entity.GetKeys())
                    key.SetName(key.GetName().ToSnakeCase());
                foreach (var foreignKey in entity.GetForeignKeys())
                    foreignKey.SetConstraintName(foreignKey.GetConstraintName().ToSnakeCase());
                foreach (var index in entity.GetIndexes())
                    index.SetName(index.GetName().ToSnakeCase());
            }
        }

    }
}
