using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetBank.Users.Domain.Entities;

namespace NetBank.Users.Infra.Data.Context
{
    public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Street)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(x => x.Number)
                .IsRequired();

            builder
                .Property(x => x.City)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.State)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.Country)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.ZipCode)
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}
