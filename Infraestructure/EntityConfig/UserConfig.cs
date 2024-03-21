using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.EntityConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).ValueGeneratedOnAdd();
            builder.Property(i => i.Id)
                    .IsRequired();
            builder.Property(un => un.UserName)
                    .IsRequired();
            builder.HasIndex(un => un.UserName).IsUnique();
            builder.Property(n => n.Name)
                    .HasMaxLength(20);
            builder.Property(s => s.Surname)
                    .HasMaxLength(20);
        }
    }
}
