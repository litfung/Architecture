using Architecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Database
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", "User");

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(user => user.Status).IsRequired();

            builder.OwnsOne(user => user.FullName, ownedBuilder =>
            {
                ownedBuilder.Property(fullName => fullName.Name).IsRequired().HasColumnName(nameof(FullName.Name)).HasMaxLength(100);
                ownedBuilder.Property(fullName => fullName.Surname).IsRequired().HasColumnName(nameof(FullName.Surname)).HasMaxLength(200);
            });

            builder.OwnsOne(user => user.Email, ownedBuilder =>
            {
                ownedBuilder.Property(email => email.Address).IsRequired().HasColumnName(nameof(User.Email)).HasMaxLength(300);
                ownedBuilder.HasIndex(email => email.Address).IsUnique();
            });

            builder.HasOne(user => user.Auth);
        }
    }
}
