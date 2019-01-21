using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using _8anu.Api.Common.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using _8anu.Api.Common.DataEntities;

namespace _8anu.Api.Data.Contexts
{
    public class DomainModelMySqlContext : DbContext, IDomainModelContext
    {
        // creating a model:
        // https://docs.microsoft.com/en-us/ef/core/modeling/

        public DomainModelMySqlContext(DbContextOptions<DomainModelMySqlContext> options) : base(options)
        { }

        public DbSet<TestModel> TestModels { get; set; }
        public DbSet<NewsItem> News { get; set; }   
        public DbSet<Country> Countries { get; set; }
        public DbSet<Crag> Crags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ForumCategory> ForumCategories { get; set; }
        public DbSet<ForumThread> ForumThreads { get; set; }
        public DbSet<ForumComment> ForumComments { get; set; }
        public DbSet<GradingSystem> GradingSystems { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Boulder> Boulders { get; set; }
        public DbSet<Ascent> Ascents { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // add unique index for Crag on Slug & Type columns
            builder.Entity<Crag>()
                   .HasIndex(c => new { c.Slug, c.Category });

            // add unique index for forum threads on Slug & category id columns
            builder.Entity<ForumThread>()
                   .HasIndex(f => new { f.Slug, f.ForumCategoryId }).IsUnique();

            // add index for ascents on zlaggable_id & zlaggable_type
            builder.Entity<Ascent>()
                .HasIndex(a => new {a.ZlaggableId, a.ZlaggableType});

            // add index for ascents on zlaggable_id, zlaggable_type and type
            // for getting statistics much faster
            builder.Entity<Ascent>()
                .HasIndex(a => new {a.ZlaggableId, a.ZlaggableType, a.Type});
            
            
            // set default value for crag areas published column
            /*
            builder.Entity<Area>()
                   .Property(a => a.Published)
                   .HasDefaultValue(true);
            */

            // convert CragCategoryEnum to string
            // TODO: when ef core 2.1 gets out
            /*
            builder
                .Entity<Crag>()
                .Property(c => c.Category)
                .HasConversion(
                    c => c.ToString(),
                    c => (CragCategoryEnum)Enum.Parse(typeof(CragCategoryEnum), c));
           */
        }

		public override int SaveChanges() // of T where T ITimeStampEntity
        {
            ChangeTracker.DetectChanges();

            AddTimeStamps<CreatedModifiedEntity>();

            return base.SaveChanges();
        }

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
            AddTimeStamps<CreatedModifiedEntity>();
			return base.SaveChangesAsync(cancellationToken);
		}

		private void AddTimeStamps<T>() where T : CreatedModifiedEntity 
        {
            //var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            var entities =
                ChangeTracker.Entries<T>()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);


            // if we later save userid
            /*
            var currentUsername = !string.IsNullOrEmpty(System.Web.HttpContext.Current?.User?.Identity?.Name)
                ? HttpContext.Current.User.Identity.Name
                : "Anonymous";
            */

            foreach (var entity in entities)
            {
                var cremodEntity = (CreatedModifiedEntity)entity.Entity;
                if (entity.State == EntityState.Added)
                {
                    if (cremodEntity.DateCreated.Year == 1)
                    {
                        cremodEntity.DateCreated = DateTime.UtcNow;
                    }
                    // cremodEntity.UserCreated = currentUsername;
                }

                cremodEntity.DateModified = DateTime.UtcNow;
                // cremodEntity.UserModified = currentUsername;
            }
                
        }
       
        public void SetEntityState(object value, EntityState entityState)
        {
            Entry(value).State = entityState;
        }

        public EntityState GetEntityState(object value)
        {
            return Entry(value).State;
        }

        public void SetEntityPropertyModified(object user, string propertyName)
        {
            Entry(user).Property(propertyName).IsModified = true;
        }
    }
}
