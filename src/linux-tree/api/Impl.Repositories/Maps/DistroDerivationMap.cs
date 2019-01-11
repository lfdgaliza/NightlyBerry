using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NightlyBerry.Common.Repository.EntityFramework;
using NightlyBerry.LinuxTree.Domain.Model;

namespace NightlyBerry.LinuxTree.Impl.Repositories.Maps
{
    public class DistroDerivationMap : MapBase<DistroDerivation>
    {
        public override void Map(EntityTypeBuilder<DistroDerivation> builder)
        {
            builder.Property(p => p.DerivesFromId).HasColumnName("DerivesFromId");
            builder.HasOne(p => p.DerivesFrom).WithMany(p => p.ChildList).HasForeignKey(p => p.DerivesFromId);

            builder.Property(p => p.ReleaseId).HasColumnName("DistroReleaseId");
            builder.HasOne(p => p.Release).WithMany(p => p.ParentList).HasForeignKey(p => p.ReleaseId);
        }
    }
}
