using Data.Configuration.BaseConfiguration;
using Domain;
using DomainShared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    public class CategoryConfiguration : BaseConfiguration<Category>
    {
        public DbSet<Category> Categories { get; set; }

        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            #region Props
            
           // builder.HasAlternateKey(c => c.CategoryId);
          //  builder.HasAlternateKey(c=>c.ParentCategoryId);

            builder.Property(c => c.CategoryName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(c => c.Description)
                   .HasMaxLength(500);


            #endregion

            #region Relationships 

            builder.HasMany(c => c.SubCategories)
               .WithOne(c => c.ParentCategory)
               .HasForeignKey(c => c.ParentCategoryId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.Products)
              .WithOne(p => p.Category)
              .HasForeignKey(p => p.CategoryId)
              .OnDelete(DeleteBehavior.Cascade);


            #endregion

            #region Seed Data

            //builder.HasData(
            //    new Category(1,"Elektronik","Tüm elektronik ürünler",null)
            //    {
            //        Guid= Guid.Parse("a49c7554-02c0-4057-8173-fc7275741100")
            //    },
            //    new Category(2,"Telefonlar","Cep Telefonları",1)
            //    {
            //        Guid = Guid.Parse("a49c7554-02c0-4057-8173-fc7275741101")
            //    },
            //    new Category(3, "Bilgisayarlar", "Tüm bilgisayarlar", 1)
            //    {
            //        Guid = Guid.Parse("a49c7554-02c0-4057-8173-fc7275741102")
            //    },
            //    new Category(4, "Akıllı Telefonlar", "Akıllı cep telefonları",2)
            //    {
            //        Guid = Guid.Parse("a49c7554-02c0-4057-8173-fc7275741103")
            //    },
            //    new Category(5, "Tabletler", "Tablet bilgisayarlar", 3)
            //    {
            //        Guid = Guid.Parse("a49c7554-02c0-4057-8173-fc7275741104")
            //    }

            //);

            #endregion

            base.Configure(builder);


        }
    }
}
