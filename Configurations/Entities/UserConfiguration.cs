using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserEntity = eShopApi.Models.Entities.User;

namespace eShopApi.Configurations.Entities
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasIndex(u => u.UserId).IsUnique();
            builder.HasIndex(u => u.Username).IsUnique();
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.Username).HasMaxLength(50).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(100).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.AvatarUrl).HasMaxLength(255);
            builder.Property(u => u.Phone).HasMaxLength(20);
            builder.Property(u => u.Gender).HasMaxLength(10);

            builder.Property(u => u.Address)
                .HasConversion(
                    v => string.Join(";", v!),
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries)
                );
        }
    }
}