using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NightlyBerry.Common.Repository.EntityFramework;
using NightlyBerry.LinuxTree.Domain.Model;

namespace NightlyBerry.LinuxTree.Impl.Repositories.Maps
{
    public class DistroRelationshipMap : MapBase<DistroRelationship>
    {
        public override void Map(EntityTypeBuilder<DistroRelationship> builder)
        {
            builder
                .HasOne(p => p.Distro)
                .WithMany(p => p.ChildDistroRelationshipList)
                .HasForeignKey(p => p.DistroId);

            builder
                .HasOne(p => p.ParentDistro)
                .WithMany(p => p.ParentDistroRelationshipList)
                .HasForeignKey(p => p.ParentDistroId);
        }
    }
}
