using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EfCoreRelationshipDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreRelationshipDemo.Data
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(p => p.Id); 
            builder.Property(p => p.Title).HasColumnName(nameof(Post.Title)).HasMaxLength(64).IsRequired(); 
            builder.Property(p => p.Content).HasColumnName(nameof(Post.Content)).HasMaxLength(256); 
            builder.Property(p => p.CategoryId).HasColumnName(nameof(Post.CategoryId)); 
            builder.HasOne(p => p.Category)
                .WithMany(c => c.Posts)
                .HasForeignKey(p => p.CategoryId)
                // Set Nullification Delete
                .OnDelete(DeleteBehavior.ClientSetNull);
        }   
    }
}