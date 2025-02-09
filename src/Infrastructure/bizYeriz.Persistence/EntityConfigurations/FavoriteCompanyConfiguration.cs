using bizYeriz.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bizYeriz.Persistence.EntityConfigurations;
public class FavoriteCompanyConfiguration : IEntityTypeConfiguration<FavoriteCompany>
{
    public void Configure(EntityTypeBuilder<FavoriteCompany> builder)
    {       
        builder.ToTable("FavoriteCompanies");
        builder.HasKey(fc => fc.Id);
        builder.Property(fc => fc.Id).ValueGeneratedOnAdd();
        builder.Property(fc => fc.UserId).IsRequired();
        builder.Property(fc => fc.CompanyId).IsRequired();
        builder.Property(fc => fc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(fc => fc.UpdatedDate).HasColumnName("UpdatedDate").IsRequired(false);
        builder.Property(fc => fc.DeletedDate).HasColumnName("DeletedDate").IsRequired(false);

        builder.HasOne(c => c.Company)
            .WithMany(fc => fc.FavoriteCompanies)
            .HasForeignKey(fc => fc.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.User)
            .WithMany(fc => fc.FavoriteCompanies)
            .HasForeignKey(fc => fc.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}