using DistroGuide.Domain.Model.Entities.Packages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Maps.Packages
{
    internal class PackageMap : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.ToTable("Package");
            builder.HasKey(k => k.Id);

            builder
                .HasOne(p => p.PackageType)
                .WithMany(p => p.PackageList)
                .HasForeignKey(p => p.PackageTypeId);

            builder
                .HasMany(p => p.PackageDistroList)
                .WithOne(p => p.Package)
                .HasForeignKey(p => p.PackageId);
        }
    }
}
