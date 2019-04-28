using System;
using DistroGuide.Domain.Repository.Entities;
using Infra.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Maps
{
    public class DistroDerivationMap : MapBase<DistroDerivationEntity>
    {
        public override void Map(EntityTypeBuilder<DistroDerivationEntity> builder)
        {
            //builder.Property(p => p.BasedOnId).HasColumnName("BasedOnId");
            //builder.HasOne(p => p.Parent).WithMany(p => p.ChildList).HasForeignKey(p => p.BasedOnId);

            //builder.Property(p => p.ReleaseId).HasColumnName("DistroId");
            //builder.HasOne(p => p.Distro).WithMany(p => p.ParentList).HasForeignKey(p => p.ReleaseId);
        }
    }
}
