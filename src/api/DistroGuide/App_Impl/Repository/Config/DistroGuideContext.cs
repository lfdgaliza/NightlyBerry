using DistroGuide.App_Domain.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace DistroGuide.App_Impl.Repository.Config
{
    public class DistroGuideContext : DbContext
    {
        public DistroGuideContext(DbContextOptions<DistroGuideContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<Distro> Distros { get; set; }
    }
}