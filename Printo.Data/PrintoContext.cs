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

    }
}
