using DistroGuide.Domain.Model.Entities.ExternalReferences;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Maps.ExternalReferences
{
    internal class ExternalReferenceMap : IEntityTypeConfiguration<ExternalReference>
    {
        public void Configure(EntityTypeBuilder<ExternalReference> builder)
        {
            builder.ToTable("ExternalReference");
            builder.HasKey(k => k.Id);

            builder
                .HasOne(p => p.ExternalReferenceType)
                .WithMany(p => p.ExternalReferenceList)
                .HasForeignKey(p => p.ExternalReferenceTypeId);
        }
    }
}
