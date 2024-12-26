using bizYeriz.Domain.Entities.AuthEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
namespace bizYeriz.Persistence.EntityConfigurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {        
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd()
            .HasValueGenerator<SequentialGuidValueGenerator>()
            .HasColumnName("Id")
            .IsRequired();

        builder.Property(u => u.RoleId).HasColumnName("RoleId").IsRequired();
        builder.Property(u => u.UserTypes).HasColumnName("UserType").IsRequired();
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired(false);
        builder.Property(u => u.Gsm).HasColumnName("Gsm").HasMaxLength(20).IsRequired(false);
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();
        builder.Property(u => u.Name).HasColumnName("Name").IsRequired(false);
        builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired(false);        
        builder.Property(u => u.BirthDate).HasColumnName("BirthDate").IsRequired(false);
        builder.Property(u => u.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(u => u.IsDelete).HasColumnName("IsDelete").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate").IsRequired(false);
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate").IsRequired(false);

        builder.HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}