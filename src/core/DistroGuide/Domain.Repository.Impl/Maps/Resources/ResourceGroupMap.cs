using DistroGuide.Domain.Model.Entities.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Maps.Resources
{
    internal class ResourceGroupMap : IEntityTypeConfiguration<ResourceGroup>
    {
        public void Configure(EntityTypeBuilder<ResourceGroup> builder)
        {
            builder.ToTable("ResourceGroup");
            builder.HasKey(p => p.Id);

            builder
                .HasMany(p => p.ResourceList)
                .WithOne(p => p.ResourceGroup)
                .HasForeignKey(p => p.ResourceGroupId);
        }
    }
}
