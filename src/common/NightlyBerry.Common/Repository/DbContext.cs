using System.Reflection;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using NightlyBerry.Common.Repository.EntityFramework;

namespace NightlyBerry.Common.Repository
{
    public class BasicDbContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        public BasicDbContext(ILoggerFactory loggerFactory, DbContextOptions<BasicDbContext> options)
            : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("NightlyBerry.LinuxTree.Impl.Repositories"), t =>
                t.IsClass
                && t.BaseType != null
                && t.BaseType.IsGenericType
                && t.BaseType.GetGenericTypeDefinition() == typeof(MapBase<>)
                && !t.IsAbstract);
        }
    }
}
