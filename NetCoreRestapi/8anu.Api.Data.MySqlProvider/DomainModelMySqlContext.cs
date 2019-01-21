using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using _8anu.Api.Common;

namespace _8anu.Api.Data.MySqlProvider
{
    public class DomainModelMySqlContext : DbContext, I8anuContext
    {
        public DomainModelMySqlContext(DbContextOptions<DomainModelMySqlContext> options) : base(options)
        { }

        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Article>().HasKey(m => m.Id);
            // shadow properties
            builder.Entity<Article>().Property<DateTime>("UpdatedTimestamp");

            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            UpdateUpdatedProperty<Article>();

            return base.SaveChanges();
        }

        private void UpdateUpdatedProperty<T>() where T : class
        {
            var modifiedSourceInfo =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in modifiedSourceInfo)
            {
                entry.Property("UpdatedTimestamp").CurrentValue = DateTime.UtcNow;
            }
        }
    }
}
