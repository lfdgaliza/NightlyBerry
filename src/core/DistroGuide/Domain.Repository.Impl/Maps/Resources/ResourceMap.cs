using DistroGuide.Domain.Model.Entities.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Maps.Resources
{
    internal class ResourceMap : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resource");
            builder.HasKey(p => p.Id);

            builder
                .HasOne(p => p.ResourceGroup)
                .WithMany(p => p.ResourceList)
                .HasForeignKey(p => p.ResourceGroupId);

            builder
                .HasMany(p => p.ResourceTranslationList)
                .WithOne(p => p.Resource)
                .HasForeignKey(p => p.ResourceId);
        }
    }
}
