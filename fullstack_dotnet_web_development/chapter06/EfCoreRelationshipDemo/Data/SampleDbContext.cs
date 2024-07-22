using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EfCoreRelationshipDemo.Models;

namespace EfCoreRelationshipDemo.Data
{
    public class SampleDbContext(DbContextOptions<SampleDbContext> options, IConfiguration configuration) : DbContext(options)
    {
        // One To Many relationship
        public DbSet<Invoice> Invoices => Set<Invoice>();
        public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();

        // Nullification delete
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<Category> Categories => Set<Category>();

        // One To One relationship
        public DbSet<Contact> Contacts => Set<Contact>();
        public DbSet<Address> Addresses => Set<Address>();

        // Many-to-Many
        public DbSet<Movie> Movies => Set<Movie>();
        public DbSet<Actor> Actors => Set<Actor>();
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Invoice>().HasData(
            //     new Invoice
            //     {
            //         Id = Guid.NewGuid(),
            //         InvoiceNumber = "INV-001",
            //         ContactName = "Andrew",
            //         Description = "Invoice for the first month",
            //         Amount = 100,
            //         InvoiceDate = new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero),
            //         DueDate = new DateTimeOffset(2023, 1, 15, 0, 0, 0, TimeSpan.Zero),
            //         Status = InvoiceStatus.AwaitPayment
            //     },
            //     new Invoice
            //     {
            //         Id = Guid.NewGuid(),
            //         InvoiceNumber = "INV-002",
            //         ContactName = "John",
            //         Description = "Invoice for the Second month",
            //         Amount = 100,
            //         InvoiceDate = new DateTimeOffset(2023, 2, 1, 0, 0, 0, TimeSpan.Zero),
            //         DueDate = new DateTimeOffset(2023, 2, 15, 0, 0, 0, TimeSpan.Zero),
            //         Status = InvoiceStatus.AwaitPayment
            //     },
            //     new Invoice
            //     {
            //         Id = Guid.NewGuid(),
            //         InvoiceNumber = "INV-003",
            //         ContactName = "Alex",
            //         Description = "Invoice for the Second month",
            //         Amount = 100,
            //         InvoiceDate = new DateTimeOffset(2023, 2, 1, 0, 0, 0, TimeSpan.Zero),
            //         DueDate = new DateTimeOffset(2023, 2, 15, 0, 0, 0, TimeSpan.Zero),
            //         Status = InvoiceStatus.AwaitPayment
            //     },
            //     new Invoice
            //     {
            //         Id = Guid.NewGuid(),
            //         InvoiceNumber = "INV-004",
            //         ContactName = "Adam",
            //         Description = "Invoice for the Second month",
            //         Amount = 100,
            //         InvoiceDate = new DateTimeOffset(2023, 2, 1, 0, 0, 0, TimeSpan.Zero),
            //         DueDate = new DateTimeOffset(2023, 2, 15, 0, 0, 0, TimeSpan.Zero),
            //         Status = InvoiceStatus.AwaitPayment
            //     }
            // );

            // Grouping the configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampleDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseMySql(
                connectionString, 
                ServerVersion.AutoDetect(connectionString)
                // // Set Query Splitting Globally
                // ,b => b.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
            );
        }
        public DbSet<EfCoreRelationshipDemo.Models.Address> Address { get; set; } = default!;
        public DbSet<EfCoreRelationshipDemo.Models.Contact> Contact { get; set; } = default!;
    }
}