using DistroGuide.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Domain.Repository.Impl.Context.Mappings
{
    public class TranslationMap : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> builder)
        {
            builder.ToTable("Translation");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Module).HasColumnName("Module");
            builder.Property(p => p.Name).HasColumnName("ResourceName");
            builder.Property(p => p.Description).HasColumnName("Description");
            builder.Property(p => p.Language).HasColumnName("Language");
            builder.Property(p => p.Value).HasColumnName("Value");
        }
    }
}
