using Architecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Architecture.Database
{
    public sealed class AuthConfiguration : IEntityTypeConfiguration<Auth>
    {
        public void Configure(EntityTypeBuilder<Auth> builder)
        {
            builder.ToTable("Auths", "Auth");

            builder.HasKey(auth => auth.Id);

            builder.HasIndex(auth => auth.Login).IsUnique();

            builder.Property(auth => auth.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(auth => auth.Login).IsRequired().HasMaxLength(100);
            builder.Property(auth => auth.Password).IsRequired().HasMaxLength(500);
            builder.Property(auth => auth.Salt).IsRequired().HasMaxLength(500);
            builder.Property(auth => auth.Roles).IsRequired();
        }
    }
}
