using Microsoft.EntityFrameworkCore;
using ECommerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Concrete.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.Property(c => c.Name)
           .IsRequired()
           .HasMaxLength(100);

            builder.Property(c => c.Description)
                 .IsRequired(false)
                 .HasMaxLength(500);
                

            builder.Property(c => c.ImageUrl)
                .HasMaxLength(200);

            builder.Property(c => c.isActive)
                .IsRequired();

           
            builder.HasMany(c => c.ProductCategories)
                  .WithOne(pc => pc.Category)
                  .HasForeignKey(pc => pc.CategoryId)
                  .OnDelete(DeleteBehavior.Cascade);



        }
        }
    }

