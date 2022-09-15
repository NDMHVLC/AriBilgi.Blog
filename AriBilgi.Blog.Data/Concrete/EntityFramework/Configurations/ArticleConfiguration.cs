using AriBilgi.Blog.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AriBilgi.Blog.Data.Concrete.EntityFramework.Configurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.Property(a => a.Title).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Content).IsRequired().HasColumnType("nvarchar(max)");


            builder.HasOne<Category>(a=>a.Category).WithMany(c=>c.Articles).HasForeignKey(a=>a.CategoryId);
            builder.HasOne<User>(a=>a.User).WithMany(u=>u.Articles).HasForeignKey(a=>a.UserId);
        }
    }
}
