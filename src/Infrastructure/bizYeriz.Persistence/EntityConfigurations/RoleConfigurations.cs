using bizYeriz.Domain.Entities.AuthEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace bizYeriz.Persistence.EntityConfigurations;

public class RoleConfigurations : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        // Tablo adı ve birincil anahtar
        builder.ToTable("Roles");
        builder.HasKey(r => r.Id);

        // Id özelliği
        builder.Property(r => r.Id)
            .ValueGeneratedOnAdd()
            .HasValueGenerator<SequentialGuidValueGenerator>()
            .HasColumnName("Id")
            .IsRequired();

        // Name özelliği
        builder.Property(r => r.Name)
            .HasColumnName("Name")
            .IsRequired();

        // Description özelliği
        builder.Property(r => r.Description)
            .HasColumnName("Description")
            .IsRequired(false);

        
        // Users ile ilişki
        builder.HasMany(r => r.Users) // Role birden çok User'a sahip
            .WithOne(u => u.Role) // User, bir Role'a ait
            .HasForeignKey(u => u.RoleId) // ForeignKey User tarafında
            .IsRequired();

        // RolePermissions ile ilişki
        builder.HasMany(r => r.RolePermissions) // Role birden çok RolePermission'a sahip
            .WithOne(rp => rp.Role) // RolePermission bir Role'a ait
            .HasForeignKey(rp => rp.RoleId) // ForeignKey RolePermission tarafında
            .IsRequired();

        builder.Property(u => u.IsActive)
           .HasColumnName("IsActive")
           .IsRequired();

        builder.Property(u => u.IsDelete)
            .HasColumnName("IsDelete")
            .IsRequired();

    }
}