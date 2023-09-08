using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NCwDDD.Domain.Models;

namespace NCwDDD.Infra.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("Id");

            builder.Property(p => p.Name)
                .HasColumnType("varchar(150)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(c => c.Product)
            .WithOne(p => p.Category)
            .HasForeignKey<Category>(c => c.Id);
        }
    }
}

