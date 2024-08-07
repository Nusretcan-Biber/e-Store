using Data.Configuration.BaseConfiguration;
using Domain;
using DomainShared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics;

namespace Data.Configuration
{
    public class ProductConfiguration : BaseConfiguration<Product>
    {
        public DbSet<Product> Products { get; set; }

        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            #region props

            builder.Property(p => p.ProductName)
                 .IsRequired()
                 .HasMaxLength(100);

            builder.Property(p => p.Description)
                   .HasMaxLength(500);

            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Stock)
                   .IsRequired();

            builder.Property(p => p.ImageURL)
                 .HasMaxLength(255);
            #endregion

            #region Relationships

            builder.HasOne(p => p.Category)
              .WithMany(c => c.Products)
              .HasForeignKey(p => p.CategoryId)
              .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Seed Data


            #endregion

            base.Configure(builder);



        }
    }
}
