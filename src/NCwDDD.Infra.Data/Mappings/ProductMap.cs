using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NCwDDD.Domain.Models;

namespace NCwDDD.Infra.Data.Mappings
{
	public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("Id");

            builder.Property(p => p.Name)
                .HasColumnType("varchar(150)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasColumnType("varchar(1000)")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasOne(p => p.Category)
            .WithOne(c => c.Product)
            .HasForeignKey<Category>(c => c.Id);
        }
    }
}

