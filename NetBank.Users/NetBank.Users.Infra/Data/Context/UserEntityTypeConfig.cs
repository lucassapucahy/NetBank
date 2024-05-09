using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetBank.Users.Domain.Entities;

namespace NetBank.Users.Infra.Data.Context
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(x => x.Id)
                .IsRequired();

            builder
                .Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(x => x.BirthDate)
                .IsRequired();


            builder
                .Property(x => x.Email)
                .HasMaxLength(255)
                .IsRequired();

            builder
                .Property(x => x.DocumentNumber)
                .HasMaxLength(20)
                .IsRequired();

            builder
                .Property(x => x.Phone)
                .HasMaxLength(50)
                .IsRequired();

            builder
                .Property(x => x.Status)
                .IsRequired();

            builder
                .Property(x => x.RequestType)
                .IsRequired();

            builder
                .HasOne(x => x.Address)
                .WithMany()
                .HasForeignKey(x => x.AddressId);

            builder
                .Property(x => x.Password)
                .IsRequired();

            builder
                .Property(x => x.Password)
                .IsRequired();
        }
    }
}
