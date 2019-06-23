using DistroGuide.Domain.Model.Entities.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Maps.Resources
{
    internal class ResourceTranslationMap : IEntityTypeConfiguration<ResourceTranslation>
    {
        public void Configure(EntityTypeBuilder<ResourceTranslation> builder)
        {
            builder.ToTable("ResourceTranslation");
            builder.HasKey(p => p.Id);


            builder
                .HasOne(p => p.Resource)
                .WithMany(p => p.ResourceTranslationList)
                .HasForeignKey(p => p.ResourceId);
        }
    }
}
