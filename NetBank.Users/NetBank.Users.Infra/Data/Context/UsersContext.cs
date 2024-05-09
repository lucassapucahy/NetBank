using Microsoft.EntityFrameworkCore;
using NetBank.Users.Domain.Entities;

namespace NetBank.Users.Infra.Data.Context
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AddressEntityTypeConfiguration().Configure(modelBuilder.Entity<Address>());
            new UserEntityTypeConfiguration().Configure(modelBuilder.Entity<User>());


            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string) && p.GetColumnType() == null))
            {
                property.SetIsUnicode(false);
            }

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified || e.State == EntityState.Added);
            foreach (var entry in entries)
            {
                if (entry.Entity is User myEntity)
                {
                    if (entry.State == EntityState.Added)
                        myEntity.CreatedAt = DateTime.Now;

                    myEntity.LastUpdate = DateTime.Now;
                }

            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
