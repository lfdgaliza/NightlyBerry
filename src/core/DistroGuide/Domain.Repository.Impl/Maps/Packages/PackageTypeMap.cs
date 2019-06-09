using DistroGuide.Domain.Model.Entities.Packages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Maps.Packages
{
    internal class PackageTypeMap : IEntityTypeConfiguration<PackageType>
    {
        public void Configure(EntityTypeBuilder<PackageType> builder)
        {
            builder.ToTable("PackageType");
            builder.HasKey(k => k.Id);

            builder
                .HasOne(p => p.Resource)
                .WithMany()
                .HasForeignKey(p => p.ResourceId);

            builder
                .HasMany(p => p.PackageList)
                .WithOne(p => p.PackageType)
                .HasForeignKey(p => p.PackageTypeId);
        }
    }
}
