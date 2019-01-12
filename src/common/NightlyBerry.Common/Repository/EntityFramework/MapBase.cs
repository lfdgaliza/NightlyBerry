using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using NightlyBerry.Common.Model;

namespace NightlyBerry.Common.Repository.EntityFramework
{
    public abstract class MapBase<T> : IEntityTypeConfiguration<T> where T : ModelBase
    {
        public abstract void Map(EntityTypeBuilder<T> builder);

        public void Configure(EntityTypeBuilder<T> builder)
        {
            Map(builder);

            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).HasColumnName("Id");
        }
    }
}
