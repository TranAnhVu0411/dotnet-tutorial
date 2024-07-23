using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConcurrencyConflictDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConcurrencyConflictDemo.Data
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(i => i.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name").HasColumnType("varchar(32)").IsRequired();
            builder.Property(p => p.Description).HasColumnName("Description").HasMaxLength(256);
            builder.Property(p => p.Price).HasColumnName("Amount").HasPrecision(18, 2);
            // // Native database-generated concurrency token
            // // Specify the RowVersion Property as rowversion column in database 
            // (Some DB will not support this, eg. SQLite)
            // modelBuilder.Entity<Product>().Property(p => p.RowVersion).IsRowVersion();
            
            // Application-managed concurrency token
            // Specify the Version Property as concurrency token (Solve above problems)
            builder.Property(p => p.Version).IsConcurrencyToken();

        }
    }
}