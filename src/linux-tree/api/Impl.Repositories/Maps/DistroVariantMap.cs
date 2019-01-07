using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NightlyBerry.Common.Repository.EntityFramework;
using NightlyBerry.LinuxTree.Domain.Model;

namespace NightlyBerry.LinuxTree.Impl.Repositories.Maps
{
    public class DistroVariantMap : MapBase<DistroVariant>
    {
        public override void Map(EntityTypeBuilder<DistroVariant> builder)
        {
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.IsMain).HasColumnName("IsMain");
            builder.Property(p => p.IsOficial).HasColumnName("IsOficial");

            builder.Property(p => p.DistroId).HasColumnName("DistroId");
            builder.HasOne(p => p.Distro).WithMany(p => p.VariantList).HasForeignKey(p => p.DistroId);
        }
    }
}
