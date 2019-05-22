using DistroGuide.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Context.Mappings
{
    public class ExternalResourceTypeMap : IEntityTypeConfiguration<ExternalResourceType>
    {
        public void Configure(EntityTypeBuilder<ExternalResourceType> builder)
        {
            builder.ToTable("ExternalResourceType");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Description).HasColumnName("Description");

            builder.Property(p => p.ResourceId).HasColumnName("ResourceId");
            builder
                .HasOne(p => p.Resource)
                .WithMany(p => p.ExternalResourceTypes)
                .HasForeignKey(p => p.ResourceId);
        }
    }
}
