using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NCwDDD.Domain.Core.Events;

namespace NCwDDD.Infra.Data.Mappings
{
    public class StoredEventMap : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.Property(c => c.Timestamp)
                .HasColumnName("CreationDate");

            builder.Property(c => c.MessageType)
                .HasColumnName("Action")
                .HasColumnType("varchar(100)");
        }
    }
}

