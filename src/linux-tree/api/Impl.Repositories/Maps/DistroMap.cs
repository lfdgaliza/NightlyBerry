using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NightlyBerry.Common.Repository.EntityFramework;
using NightlyBerry.LinuxTree.Domain.Model;

namespace NightlyBerry.LinuxTree.Impl.Repositories.Maps
{
    public class DistroMap : MapBase<Distro>
    {
        public override void Map(EntityTypeBuilder<Distro> builder)
        {
            builder.Property(p => p.Name).HasColumnName("Name");
        }
    }
}
