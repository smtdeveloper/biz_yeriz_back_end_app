using bizYeriz.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bizYeriz.Persistence.EntityConfigurations;
public class CompanyUserConfiguration : IEntityTypeConfiguration<CompanyUser>
{
    public void Configure(EntityTypeBuilder<CompanyUser> builder)
    {
        
        builder.ToTable("CompanyUsers");
        builder.HasKey(cu => cu.Id);
        builder.Property(cu => cu.Position);
        builder.Property(cu => cu.UserId).IsRequired(); builder.Property(cu => cu.UserId).IsRequired();       
        builder.Property(cc => cc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cc => cc.UpdatedDate).HasColumnName("UpdatedDate").IsRequired(false);
        builder.Property(cc => cc.DeletedDate).HasColumnName("DeletedDate").IsRequired(false);

        builder
            .HasOne(cu => cu.User) 
            .WithOne(u => u.CompanyUser) 
            .HasForeignKey<CompanyUser>(cu => cu.UserId) 
            .OnDelete(DeleteBehavior.Restrict);
    }
}