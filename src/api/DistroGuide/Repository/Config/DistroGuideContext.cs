using DistroGuide.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository.Config
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