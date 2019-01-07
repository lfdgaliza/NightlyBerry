using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NightlyBerry.Common.Repository.EntityFramework;
using NightlyBerry.LinuxTree.Domain.Model;

namespace NightlyBerry.LinuxTree.Impl.Repositories.Maps
{
    public class DistroReleaseMap : MapBase<DistroRelease>
    {
        public override void Map(EntityTypeBuilder<DistroRelease> builder)
        {
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.ReleaseDate).HasColumnName("ReleaseDate");

            builder.Property(p => p.VariantId).HasColumnName("VariantId");
            builder.HasOne(p => p.Variant).WithMany(p => p.ReleaseList).HasForeignKey(p => p.VariantId);
        }
    }
}
