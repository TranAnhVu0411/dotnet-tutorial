using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreRelationshipDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreRelationshipDemo.Data
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(p => p.Id); 
            builder.Property(p => p.Name).HasColumnName(nameof(Category.Name)).HasMaxLength(64).IsRequired();
        }   
    }
}