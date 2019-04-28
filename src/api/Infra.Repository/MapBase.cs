using System;
using DistroGuide.Infra.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Repository
{
    public abstract class MapBase<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public abstract void Map(EntityTypeBuilder<T> builder);

        public void Configure(EntityTypeBuilder<T> builder)
        {
            Map(builder);

            builder.HasKey(p => p.Id);
            //builder.Property(e => e.Id).HasColumnName("Id");
        }
    }
}
