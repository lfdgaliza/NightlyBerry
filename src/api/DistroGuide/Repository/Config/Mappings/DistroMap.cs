using DistroGuide.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DistroGuide.Repository.Config.Mappings
{
    public class DistroMap : IEntityTypeConfiguration<Distro>
    {
        public void Configure(EntityTypeBuilder<Distro> builder)
        {
            builder.ToTable("Distro");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.Name).HasColumnName("Name");
            builder.Property(p => p.HomePage).HasColumnName("HomePage");
            builder.Property(p => p.IconUrl).HasColumnName("Icon");

            builder.Property(p => p.BasedOnId).HasColumnName("BasedOn");
            builder.HasOne(p => p.BasedOn).WithMany(p => p.Children).HasForeignKey(p => p.BasedOnId);
        }
    }
}