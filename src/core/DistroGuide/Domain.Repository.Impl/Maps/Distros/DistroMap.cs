using DistroGuide.Domain.Model.Entities.Distros;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Maps.Distros
{
    internal class DistroMap : IEntityTypeConfiguration<Distro>
    {
        public void Configure(EntityTypeBuilder<Distro> builder)
        {
            builder.ToTable("Distro");
            builder.HasKey(p => p.Id);

            builder
                .HasOne(p => p.BasedOn)
                .WithMany(p => p.ChildList)
                .HasForeignKey(p => p.BasedOnId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(p => p.ExternalReferenceList)
                .WithOne()
                .HasForeignKey(k => k.TargetId);
        }
    }
}
