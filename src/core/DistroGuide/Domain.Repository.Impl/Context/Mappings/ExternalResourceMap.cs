using DistroGuide.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Context.Mappings
{
    public class DistroExternalResourceMap : IEntityTypeConfiguration<ExternalResource>
    {
        public void Configure(EntityTypeBuilder<ExternalResource> builder)
        {
            builder.ToTable("ExternalResource");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.IsPrincipal).HasColumnName("IsPrincipal");
            builder.Property(p => p.Resource).HasColumnName("Resource");
            builder.Property(p => p.TargetId).HasColumnName("TargetId");
            builder.Property(p => p.TargetType).HasColumnName("TargetType");
            builder.Property(p => p.ExternalResourceTypeId).HasColumnName("ExternalResourceTypeId");
    }
    }
}
