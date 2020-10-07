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
        public DbSet<Event> Events { get; set; }

        // SEEDERY

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region CLIENTS
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    ClientID = 1,
                    Name = "Joe Doe",
                    CompanyFullName = "Joe Doe Co",
                    NIP = "123456789",
                    Street = "Lwowska",
                    HouseNumber = "218b",
                    PostalCode = "33-300",
                    City = "Nowy Sącz",
                    Email = "jd@gmail.com",
                    Phone = "666666666",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Client
                {
                    ClientID = 2,
                    Name = "MikeShinoda",
                    CompanyFullName = "MikeShinoda Co",
                    NIP = "123456789",
                    Street = "Wallstreet",
                    HouseNumber = "52669",
                    PostalCode = "52-300",
                    City = "Nowy Jork",
                    Email = "mikeshinoda@gmail.com",
                    Phone = "555777333",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Client
                {
                    ClientID = 3,
                    Name = "Vitberg",
                    CompanyFullName = "Vitberg Jacek Sikora",
                    NIP = "123456789",
                    Street = "Borelowskiego",
                    HouseNumber = "3",
                    PostalCode = "33-300",
                    City = "Nowy Sącz",
                    Email = "js@gmail.com",
                    Phone = "666666666",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }
                );
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
                },
                new DeliveryType
                {
                    DeliveryTypeID = 2,
                    Name = "Dostawa",
                    Description = "Dostawa do klienta",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new DeliveryType
                {
                    DeliveryTypeID = 3,
                    Name = "Wysyłka",
                    Description = "Wysyłka kurierska",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new DeliveryType
                {
                    DeliveryTypeID = 4,
                    Name = "Wysyłka za pobraniem",
                    Description = "Wysyłka kurieska z opcją za pobraniem",
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
                    Name = "Brak",
                    Description = "Brak uszlachetnień druku",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Finishing
                {
                    FinishingID = 2,
                    Name = "1/0 Folia BŁYSK",
                    Description = "Folia błysk jednostronnie na awersie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Finishing
                {
                    FinishingID = 3,
                    Name = "1/0 Folia MAT",
                    Description = "Folia mat jednostronnie na awersie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Finishing
                {
                    FinishingID = 4,
                    Name = "1/0 Folia SOFT",
                    Description = "Folia soft-touch jednostronnie na awersie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Finishing
                {
                    FinishingID = 5,
                    Name = "1/1 Folia BŁYSK",
                    Description = "Folia błysk obustronnie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Finishing
                {
                    FinishingID = 6,
                    Name = "1/1 Folia MAT",
                    Description = "Folia mat obustronnie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Finishing
                {
                    FinishingID = 7,
                    Name = "1/1 Folia SOFT",
                    Description = "Folia soft-touch obustronnie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Finishing
                {
                    FinishingID = 8,
                    Name = "1/0 Folia MAT + UV wybiórczo",
                    Description = "Folia mat jednostronnie i lakier wybiórczo błysk na awersie",
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
                    Name = "Inny",
                    Description = "Wymiary w uwagach do druku",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                }, 
                new Format
                {
                    FormatID = 2,
                    Name = "A2+",
                    Description = "440x630mm",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Format
                {
                    FormatID = 3,
                    Name = "A2",
                    Description = "420x610mm",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Format
                {
                    FormatID = 4,
                    Name = "A3",
                    Description = "297x420mm",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Format
                {
                    FormatID = 5,
                    Name = "A4",
                    Description = "210x297mm",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Format
                {
                    FormatID = 6,
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
                    Name = "N/D",
                    Description = "Nie dotyczy",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Machine
                {
                    MachineID = 2,
                    Name = "KBA",
                    Description = "Druk offsetowy KBA RAPIDA 75",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Machine
                {
                    MachineID = 3,
                    Name = "RYOBI",
                    Description = "Druk offsetowy RYOBI",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Machine
                {
                    MachineID = 4,
                    Name = "XEROX",
                    Description = "Druk cyfrowy XEROX D700",
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
                    Name = "Inny",
                    Description = "Szczegóły w uwagach do druku",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PaperType
                {
                    PaperTypeID = 2,
                    Name = "Kreda mat",
                    Description = "Papier powlekany matowy",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PaperType
                {
                    PaperTypeID = 3,
                    Name = "Kreda błysk",
                    Description = "Papier powlekany błyszczący",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PaperType
                {
                    PaperTypeID = 4,
                    Name = "Offset",
                    Description = "Papier niepowlekany typu offset",
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
                    Grammature = "Inna",
                    Description = "Szczegóły w opisie druku",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PaperWeight
                {
                    PaperWeightID = 2,
                    Grammature = "130g",
                    Description = "",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PaperWeight
                {
                    PaperWeightID = 3,
                    Grammature = "170g",
                    Description = "",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PaperWeight
                {
                    PaperWeightID = 4,
                    Grammature = "200g",
                    Description = "",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PaperWeight
                {
                    PaperWeightID = 5,
                    Grammature = "350g + 170g",
                    Description = "",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PaperWeight
                {
                    PaperWeightID = 6,
                    Grammature = "250g + 130g",
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
                },
                new PaymentType
                {
                    PaymentTypeID = 2,
                    Name = "Gotówka",
                    Description = "Gotówka przy odbiorze",
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
                    Name = "Brak",
                    Description = "Brak obróbki introligatorskiej",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PostPress
                {
                    PostPressID = 2,
                    Name = "Docięcie",
                    Description = "Docięcie do formatu",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PostPress
                {
                    PostPressID = 3,
                    Name = "Oprawa zeszytowa",
                    Description = "2 zszywki płaskie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PostPress
                {
                    PostPressID = 4,
                    Name = "Oprawa klejona",
                    Description = "Oprawa miękka klejona",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PostPress
                {
                    PostPressID = 5,
                    Name = "Falcowanie",
                    Description = "Składanie do formatu",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PostPress
                {
                    PostPressID = 6,
                    Name = "Inna obróbka",
                    Description = "Szczgóły w opisie do zamówienia",
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
                    Name = "N/D",
                    Description = "Nie dotyczy",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PrintColor
                {
                    PrintColorID = 2,
                    Name = "4/0 CMYK",
                    Description = "CMYK jednostronnie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PrintColor
                {
                    PrintColorID = 3,
                    Name = "4/4 CMYK",
                    Description = "CMYK obustronnie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PrintColor
                {
                    PrintColorID = 4,
                    Name = "1/0 blacK",
                    Description = "Czarny jednostronnie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PrintColor
                {
                    PrintColorID = 5,
                    Name = "1/1 blacK",
                    Description = "Czarny obustronnie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PrintColor
                {
                    PrintColorID = 6,
                    Name = "4/4 CMYK + 1/1 blacK",
                    Description = "Okładka: CMYK obustronnie + Środek: czarny obustronnie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PrintColor
                {
                    PrintColorID = 7,
                    Name = "1/0 Pantone",
                    Description = "Pantone jednostronnie",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new PrintColor
                {
                    PrintColorID = 8,
                    Name = "Inny",
                    Description = "Szczegóły w uwagach do druku",
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
                    Name = "NOWE",
                    Description = "Nowe zamówienie przyjęte do realizacji",
                    Color = "#ffffff",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new ProductionStage
                {
                    ProductionStageID = 2,
                    Name = "CTP",
                    Description = "Naświetlanie CTP",
                    Color = "#fdaa1c",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new ProductionStage
                {
                    ProductionStageID = 3,
                    Name = "START",
                    Description = "Etap drukowania",
                    Color = "#1ae000",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new ProductionStage
                {
                    ProductionStageID = 4,
                    Name = "STOP",
                    Description = "Produkcja zatrzymana/anulowana",
                    Color = "#f62323",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new ProductionStage
                {
                    ProductionStageID = 5,
                    Name = "INTRO",
                    Description = "Obróbka introligatorska i uszlachetnienia",
                    Color = "#00a8f0",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new ProductionStage
                {
                    ProductionStageID = 6,
                    Name = "GOTOWE",
                    Description = "Produkcja zakończona - zamówienie gotowe do wydania",
                    Color = "#000000",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new ProductionStage
                {
                    ProductionStageID = 7,
                    Name = "KONIEC",
                    Description = "Zamówienie zrealizowane",
                    Color = "#ffffff",
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
                    Name = "Inny",
                    Description = "Szczegóły w opisie zamówienia",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Product
                {
                    ProductID = 2,
                    Name = "Arkusz plano",
                    Description = "Arkusze bez obróbki introligatorskiej",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Product
                {
                    ProductID = 3,
                    Name = "Ulotka standardowa",
                    Description = "Ulotka standardowa cięta do formatu",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Product
                {
                    ProductID = 4,
                    Name = "Plakat",
                    Description = "Plakat standardowy cięty do formatu",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Product
                {
                    ProductID = 5,
                    Name = "Katalog szyty",
                    Description = "Szycie zeszytowe standrd lub oczkowe",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new Product
                {
                    ProductID = 6,
                    Name = "Katalog klejony",
                    Description = "Oprawa miękka klejona",
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
                    Name = "N/D",
                    Description = "Nie dotyczy",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new SheetSize
                {
                    SheetSizeID = 2,
                    Name = "A2+",
                    Description = "630x440mm",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new SheetSize
                {
                    SheetSizeID = 3,
                    Name = "A2",
                    Description = "610x430mm",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new SheetSize
                {
                    SheetSizeID = 4,
                    Name = "A3+",
                    Description = "440x315mm",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new SheetSize
                {
                    SheetSizeID = 5,
                    Name = "B2",
                    Description = "700x500mm",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new SheetSize
                {
                    SheetSizeID = 6,
                    Name = "B3",
                    Description = "500x350mm",
                    IsActive = true,
                    AddedDate = DateTime.Now,
                    AddedUserID = 1
                },
                new SheetSize
                {
                    SheetSizeID = 7,
                    Name = "Inny",
                    Description = "Szczegóły w uwagach do druku",
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
                    Name = "Przykładowa notatka",
                    Description = "Zamówić 2 ryzy papieru",
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
