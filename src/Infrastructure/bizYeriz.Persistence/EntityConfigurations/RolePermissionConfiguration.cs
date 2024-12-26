using bizYeriz.Domain.Entities.AuthEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable("RolePermissions");
        builder.HasKey(rp => new { rp.RoleId, rp.PermissionId });
        builder.Property(cc => cc.CreatedDate).HasColumnName("CreatedDate").IsRequired();

        builder.HasOne(rp => rp.Role)
            .WithMany(r => r.RolePermissions) 
            .HasForeignKey(rp => rp.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(rp => rp.Permission)
            .WithMany(p => p.RolePermissions) 
            .HasForeignKey(rp => rp.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}