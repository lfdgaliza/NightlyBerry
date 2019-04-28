using System;
using DistroGuide.Domain.Repository.Entities;
using Infra.Repository;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Maps
{
    public class DistroMap : MapBase<DistroEntity>
    {
        public override void Map(EntityTypeBuilder<DistroEntity> builder)
        {
            //builder.Property(p => p.Name).HasColumnName("Name");
        }
    }
}
