using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BasicEfCoreDemo.Models;

namespace BasicEfCoreDemo.Data
{
    public class InvoiceDbContext(DbContextOptions<InvoiceDbContext> options) : DbContext(options)
    {
        public DbSet<Invoice> Invoices => Set<Invoice>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    InvoiceNumber = "INV-001",
                    ContactName = "Andrew",
                    Description = "Invoice for the first month",
                    Amount = 100,
                    InvoiceDate = new DateTimeOffset(2023, 1, 1, 0, 0, 0, TimeSpan.Zero),
                    DueDate = new DateTimeOffset(2023, 1, 15, 0, 0, 0, TimeSpan.Zero),
                    Status = InvoiceStatus.AwaitPayment
                },
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    InvoiceNumber = "INV-002",
                    ContactName = "John",
                    Description = "Invoice for the Second month",
                    Amount = 100,
                    InvoiceDate = new DateTimeOffset(2023, 2, 1, 0, 0, 0, TimeSpan.Zero),
                    DueDate = new DateTimeOffset(2023, 2, 15, 0, 0, 0, TimeSpan.Zero),
                    Status = InvoiceStatus.Paid
                },
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    InvoiceNumber = "INV-003",
                    ContactName = "Alex",
                    Description = "Invoice for the Second month",
                    Amount = 100,
                    InvoiceDate = new DateTimeOffset(2023, 2, 1, 0, 0, 0, TimeSpan.Zero),
                    DueDate = new DateTimeOffset(2023, 2, 15, 0, 0, 0, TimeSpan.Zero),
                    Status = InvoiceStatus.AwaitPayment
                },
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    InvoiceNumber = "INV-004",
                    ContactName = "Adam",
                    Description = "Invoice for the Second month",
                    Amount = 100,
                    InvoiceDate = new DateTimeOffset(2023, 2, 1, 0, 0, 0, TimeSpan.Zero),
                    DueDate = new DateTimeOffset(2023, 2, 15, 0, 0, 0, TimeSpan.Zero),
                    Status = InvoiceStatus.Draft
                }
            );

            // // Configure the entity
            // modelBuilder.Entity<Invoice>(b =>
            // {
            //     b.ToTable("Invoices");
            //     b.HasKey(i => i.Id);
            //     b.Property(p => p.Id).HasColumnName("Id");
            //     b.Property(p => p.InvoiceNumber).HasColumnName("InvoiceNumber").HasColumnType("varchar(32)").IsRequired();
            //     b.Property(p => p.ContactName).HasColumnName("ContactName").HasMaxLength(32).IsRequired();
            //     b.Property(p => p.Description).HasColumnName("Description").HasMaxLength(256);
            //     b.Property(p => p.Amount).HasColumnName("Amount").HasColumnType("decimal(18,2)").IsRequired();
            //     b.Property(p => p.InvoiceDate).HasColumnName("InvoiceDate").HasColumnType("datetime").IsRequired();
            //     b.Property(p => p.DueDate).HasColumnName("DueDate").HasColumnType("datetime").IsRequired();
            //     b.Property(p => p.Status).HasColumnName("Status").HasMaxLength(16).HasConversion(
            //             v => v.ToString(),
            //             v => (InvoiceStatus)Enum.Parse(typeof(InvoiceStatus), v));
            // });

            // // Seperate Entity Configuration code to the new file for cleaner code
            // // Use extension methods to configure the entity
            // modelBuilder.ConfigureInvoice();

            // // Use IEntityTypeConfiguration<TEntity> interface
            // modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            // // Or
            // new InvoiceConfiguration().Configure(modelBuilder.Entity<Invoice>());

            // // Grouping the configurations
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InvoiceDbContext).Assembly);
        }
    }
}