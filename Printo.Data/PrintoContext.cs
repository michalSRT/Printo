using Microsoft.EntityFrameworkCore;
using System;

namespace Printo.Data.Data
{
    public class PrintoContext : DbContext
    {
        public PrintoContext (DbContextOptions<PrintoContext> options)
            :base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public DbSet<DeliveryAdress> DeliveryAdresses { get; set; }
        public DbSet<DeliveryType> DeliveryTypes { get; set; }
        public DbSet<Finishing> Finishings { get; set; }
        public DbSet<Format> Formats { get; set; }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<PaperWeight> PaperWeights { get; set; }
        public DbSet<PaperType> PaperTypes { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<PostPress> PostPresses { get; set; }
        public DbSet<PrintColor> PrintColors { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductionStage> ProductionStages { get; set; }
        public DbSet<SheetSize> SheetSizes { get; set; }
        public DbSet<VatRate> VatRates { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        // SEEDERY

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region CLIENTS
            //modelBuilder.Entity<Client>().HasData(
            //    new Client
            //    {
            //        ClientID = 1,
            //        FirstName = "Joe",
            //        LastName = "Doe",
            //        CompanyName = "Joe Doe",
            //        CompanyFullName = "Joe Doe Co",
            //        NIP = "7340039619",
            //        Street = "Lwowska",
            //        HouseNumber = "218b",
            //        AppartmentNumber = null,
            //        PostalCode = "33-300",
            //        City = "Nowy Sącz",
            //        Email = "jd@gmail.com",
            //        Phone = "666666666",
            //        Description = null,
            //        IsActive = true,
            //        AddedDate = DateTime.Now,
            //        AddedUserID = 1
            //    }
            //    );
            #endregion

            #region USERS
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    Login = "admin",
                    Password = "admin",
                    Name = "Admin",
                    Surname = "Admin",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    UserTypeID = 1
                }
                );
            #endregion

            #region USERTYPES
            modelBuilder.Entity<UserType>().HasData(
                new UserType
                {
                    UserTypeID = 1,
                    Name = "Admin",
                    Description = "Administrator systemu",
                    IsActive = true,
                    AddedDate = DateTime.Now
                },
                new UserType
                {
                    UserTypeID = 2,
                    Name = "Pracownik",
                    Description = "Pracownik",
                    IsActive = true,
                    AddedDate = DateTime.Now
                }
                );
            #endregion

            #region VAT RATES
            modelBuilder.Entity<VatRate>().HasData(
                new VatRate
                {
                    VatRateID = 1,
                    Name = "23%",
                    Rate = 23,
                    Description = "Standardowa stawka Vat",
                    IsActive = true,
                    AddedDate = DateTime.Now
                },
                new VatRate
                {
                    VatRateID = 2,
                    Name = "8%",
                    Rate = 8,
                    Description = "Stawka Vat przy numerze ISSN",
                    IsActive = true,
                    AddedDate = DateTime.Now
                },
                new VatRate
                {
                    VatRateID = 3,
                    Name = "5%",
                    Rate = 5,
                    Description = "Stawka Vat przy numerze ISBN",
                    IsActive = true,
                    AddedDate = DateTime.Now
                },
                new VatRate
                {
                    VatRateID = 5,
                    Name = "nd",
                    Rate = 0,
                    Description = "Nie dotyczy",
                    IsActive = true,
                    AddedDate = DateTime.Now
                }
                );
            #endregion

            #region DELIVERY ADRESSES
            //modelBuilder.Entity<DeliveryAdress>().HasData(
            //    new DeliveryAdress
            //    {
            //        DeliveryAdressID = 1,
            //        ContactName = "Joe Doe",
            //        CompanyName = "Joe Doe Co",
            //        Phone = "784 138 949",
            //        Street = "Lwowska",
            //        HouseNumber = "54",
            //        AppartmentNumber = "1",
            //        PostalCode = "33-300",
            //        City = "Nowy Sącz",
            //        IsActive = true,
            //        AddedDate = DateTime.Now,
            //        AddedUserID = 1,
            //        ClientID = 1
            //    }
            //    );
            #endregion

            #region DELIVERY TYPES
            modelBuilder.Entity<DeliveryType>().HasData(
                new DeliveryType
                {
                    DeliveryTypeID = 1,
                    Name = "Odbiór",
                    Description = "Odbiór osobisty przez klienta",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }
                );
            #endregion

            #region FINISHINGS
            modelBuilder.Entity<Finishing>().HasData(
                new Finishing
                {
                    FinishingID = 1,
                    Name = "Folia błysk 1/0",
                    Description = "Folia błysk jednostronnie na awersie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }
                );
            #endregion

            #region FORMATS
            modelBuilder.Entity<Format>().HasData(
                new Format
                {
                    FormatID = 1,
                    Name = "A4",
                    Description = "210x297mm",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Format
                {
                    FormatID = 2,
                    Name = "A5",
                    Description = "148x210mm",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }
                );
            #endregion

            #region MACHINES
            modelBuilder.Entity<Machine>().HasData(
                new Machine
                {
                    MachineID = 1,
                    Name = "KBA",
                    Description = "RAPIDA 75",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }
                );
            #endregion

            #region PAPER TYPES
            modelBuilder.Entity<PaperType>().HasData(
                new PaperType
                {
                    PaperTypeID = 1,
                    Name = "Kreda mat",
                    Description = "Papier powlekany matowy",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }
                );
            #endregion

            #region PAPER WEIGHTS
            modelBuilder.Entity<PaperWeight>().HasData(
                new PaperWeight
                {
                    PaperWeightID = 1,
                    Grammature = "130g",
                    Description = "",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }
                );
            #endregion

            #region PAYMENT TYPES
            modelBuilder.Entity<PaymentType>().HasData(
                new PaymentType
                {
                    PaymentTypeID = 1,
                    Name = "Przelew",
                    Description = "Przelew bankowy termin min. 14 dni",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }
                );
            #endregion

            #region POST PRESSES
            modelBuilder.Entity<PostPress>().HasData(
                new PostPress
                {
                    PostPressID = 1,
                    Name = "Szycie zeszytowe standard",
                    Description = "2 zszywki płaskie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PostPress
                {
                    PostPressID = 2,
                    Name = "Szycie zeszytowe oczko",
                    Description = "2 zszywki euro",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }
                );
            #endregion

            #region PRINT COLORS
            modelBuilder.Entity<PrintColor>().HasData(
                new PrintColor
                {
                    PrintColorID = 1,
                    Name = "4/0 CMYK",
                    Description = "CMYK jednostronnie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PrintColor
                {
                    PrintColorID = 2,
                    Name = "4/4 CMYK",
                    Description = "CMYK obustronnie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }
                );
            #endregion

            #region PRODUCTION STAGES
            modelBuilder.Entity<ProductionStage>().HasData(
                new ProductionStage
                {
                    ProductionStageID = 1,
                    Name = "DTP",
                    Description = "Przygotowanie do druku.",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new ProductionStage
                {
                    ProductionStageID = 2,
                    Name = "CTP",
                    Description = "Naświetlanie CTP",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new ProductionStage
                {
                    ProductionStageID = 3,
                    Name = "Druk",
                    Description = "Naświetlanie CTP",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }
                );
            #endregion

            #region PRODUCTS
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = 1,
                    Name = "Katalog szyty",
                    Description = "",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Product
                {
                    ProductID = 2,
                    Name = "Ulotka",
                    Description = "Standardowa",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Product
                {
                    ProductID = 3,
                    Name = "Plakat",
                    Description = "Standard",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }
                );
            #endregion

            #region SHEET SIZES
            modelBuilder.Entity<SheetSize>().HasData(
                new SheetSize
                {
                    SheetSizeID = 1,
                    Name = "A2+",
                    Description = "630x440mm",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new SheetSize
                {
                    SheetSizeID = 2,
                    Name = "A2",
                    Description = "610x430mm",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new SheetSize
                {
                    SheetSizeID = 3,
                    Name = "B2",
                    Description = "700x500mm",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }
                );
            #endregion

            #region TO DO
            modelBuilder.Entity<ToDo>().HasData(
                new ToDo
                {
                    ToDoID = 1,
                    Name = "Zamówić matryce",
                    Description = "Sonory 2 paczki",
                    Date = DateTime.Now,
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }
                );
            #endregion
        }

    }
}
