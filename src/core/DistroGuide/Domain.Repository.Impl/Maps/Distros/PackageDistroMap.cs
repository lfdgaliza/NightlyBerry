using DistroGuide.Domain.Model.Entities.Distros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Maps.Distros
{
    internal class PackageDistroMap : IEntityTypeConfiguration<PackageDistro>
    {
        public void Configure(EntityTypeBuilder<PackageDistro> builder)
        {
            builder.ToTable("PackageDistro");
            builder.HasKey(p => p.Id);

            builder
                .HasOne(p => p.Distro)
                .WithMany(p => p.PackageDistroList)
                .HasForeignKey(p => p.DistroId);

            builder
                .HasOne(p => p.Package)
                .WithMany(p => p.PackageDistroList)
                .HasForeignKey(p => p.PackageId);
        }
    }
}
