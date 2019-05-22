using DistroGuide.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Context.Mappings
{
    class DistroMap : IEntityTypeConfiguration<Distro>
    {
        public void Configure(EntityTypeBuilder<Distro> builder)
        {
            builder.ToTable("Distro");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name");

            builder.Property(p => p.IconUrl).HasColumnName("Icon");

            builder.Property(p => p.BasedOnId).HasColumnName("BasedOn");
            builder.HasOne(p => p.BasedOn).WithMany(p => p.Children).HasForeignKey(p => p.BasedOnId);

            builder.HasMany(p => p.ExternalResources).WithOne().HasForeignKey(k => k.TargetId);
        }
    }
}
