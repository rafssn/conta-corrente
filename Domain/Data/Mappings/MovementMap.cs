using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Domain.Data.Mappings
{
    public class MovementMap : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            builder.ToTable("Movements");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnName("Balance")
                .HasColumnType("DECIMAL")
                .HasPrecision(13, 2);

            builder.Property(x => x.Type)
                .IsRequired()
                .HasColumnName("Type")
                .HasColumnType("INT");

            builder.Property(x => x.AccountId)
                .IsRequired()
                .HasColumnName("AccountId")
                .HasColumnType("INT");
        }
    }
}
