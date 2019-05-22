using DistroGuide.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Context.Mappings
{
    public class ResourceTranslationMap : IEntityTypeConfiguration<ResourceTranslation>
    {
        public void Configure(EntityTypeBuilder<ResourceTranslation> builder)
        {
            builder.ToTable("ResourceTranslation");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Language).HasColumnName("Language");
            builder.Property(p => p.Translation).HasColumnName("Translation");

            builder.Property(p => p.ResourceId).HasColumnName("ResourceId");
            builder
                .HasOne(p => p.Resource)
                .WithMany(p => p.ResourceTranslations)
                .HasForeignKey(p => p.ResourceId);
        }
    }
}
