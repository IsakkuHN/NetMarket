using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinessLogic.Data.Configuration {
    public class ProductConfiguration : IEntityTypeConfiguration<Product> {
        public void Configure(EntityTypeBuilder<Product> builder) {
            
            builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Image).HasMaxLength(1000);
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");

            //Relations Mapping
            builder.HasOne(m => m.Brand).WithMany().HasForeignKey(p => p.BrandId); 
            builder.HasOne(c => c.Category).WithMany().HasForeignKey(p => p.CategoryId);
        }
    }
}
