using DistroGuide.Domain.Model.Entities.ExternalReferences;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Maps.ExternalReferences
{
    internal class ExternalReferenceTypeMap : IEntityTypeConfiguration<ExternalReferenceType>
    {
        public void Configure(EntityTypeBuilder<ExternalReferenceType> builder)
        {
            builder.ToTable("ExternalReferenceType");
            builder.HasKey(k => k.Id);

            builder
                .HasOne(p => p.Resource)
                .WithMany()
                .HasForeignKey(p => p.ResourceId);

            builder
                .HasMany(p => p.ExternalReferenceList)
                .WithOne(p => p.ExternalReferenceType)
                .HasForeignKey(p => p.ExternalReferenceTypeId);
        }
    }
}
