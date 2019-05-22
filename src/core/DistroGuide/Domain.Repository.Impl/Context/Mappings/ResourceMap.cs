using DistroGuide.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Context.Mappings
{
    public class ResourceMap : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.ToTable("Resource");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Description).HasColumnName("Description");
            builder.Property(p => p.Classification).HasColumnName("Classification");
            builder.Property(p => p.Name).HasColumnName("Name");

            builder
                .HasMany(p => p.ExternalResourceTypes)
                .WithOne(p => p.Resource)
                .HasForeignKey(p => p.ResourceId);
        }
    }
}
