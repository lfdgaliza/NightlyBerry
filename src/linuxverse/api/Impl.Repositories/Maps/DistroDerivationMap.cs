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
            builder.Property(p => p.BasedOnId).HasColumnName("BasedOnId");
            builder.HasOne(p => p.Parent).WithMany(p => p.ChildList).HasForeignKey(p => p.BasedOnId);

            builder.Property(p => p.ReleaseId).HasColumnName("DistroId");
            builder.HasOne(p => p.Distro).WithMany(p => p.ParentList).HasForeignKey(p => p.ReleaseId);
        }
    }
}
