using ECommerce.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Concrete.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);


            builder.Property(p => p.UnitPrice)
                 .HasColumnType("decimal(18,2)");
            

            builder.Property(p => p.CreatedDate)
                .HasDefaultValueSql("GETUTCDATE()");

            builder.Property(p => p.ModifiedDate)
                .IsRequired(false);


            builder.Property(oi => oi.isDeleted)
          .HasDefaultValue(false);

            builder.HasMany(p => p.ProductCategories)
                  .WithOne(pc => pc.Product)
                  .HasForeignKey(pc => pc.ProductId);

            builder.HasIndex(b => b.UnitPrice)
                  .HasDatabaseName("IX_Product_Price"); 

        }
    }
}
