using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreRelationshipDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreRelationshipDemo.Data
{
    public class InvoiceItemConfiguration : IEntityTypeConfiguration<InvoiceItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceItem> builder)
        {
            builder.ToTable("InvoiceItems"); 
            builder.HasKey(p => p.Id); 
            builder.Property(p => p.Name).HasColumnName(nameof(InvoiceItem.Name)).HasMaxLength(64).IsRequired(); 
            builder.Property(p => p.Description).HasColumnName(nameof(InvoiceItem.Description)).HasMaxLength(256); 
            builder.Property(p => p.UnitPrice).HasColumnName(nameof(InvoiceItem.UnitPrice)).HasPrecision(8, 2); 
            builder.Property(p => p.Quantity).HasColumnName(nameof(InvoiceItem.Quantity)).HasPrecision(8, 2); 
            builder.Property(p => p.Amount).HasColumnName(nameof(InvoiceItem.Amount)).HasPrecision(18, 2); 
            builder.Property(p => p.InvoiceId).HasColumnName(nameof(InvoiceItem.InvoiceId));

            // // Explicitly Configure one to many relationship
            // builder.HasOne(x => x.Invoice)
            //     .WithMany(x => x.InvoiceItems)
            //     .HasForeignKey(x => x.InvoiceId)
            //     .OnDelete(DeleteBehavior.Cascade);
        }
    }
}