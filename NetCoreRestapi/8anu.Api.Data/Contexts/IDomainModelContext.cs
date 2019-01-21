using System;
using Microsoft.EntityFrameworkCore;
using _8anu.Api.Common.DataEntities;

namespace _8anu.Api.Data.Contexts
{
    public interface IDomainModelContext : IDisposable
    {
        DbSet<TestModel> TestModels { get; set; }
        DbSet<NewsItem> News { get; set; }
        DbSet<Country> Countries { get; set; }
        int SaveChanges();
        void SetEntityState(object value, EntityState entityState);
        EntityState GetEntityState(object value);
        void SetEntityPropertyModified(object user, string propertyName);
    }
}
