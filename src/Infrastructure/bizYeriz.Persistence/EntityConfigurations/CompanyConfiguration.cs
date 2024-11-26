using bizYeriz.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace bizYeriz.Persistence.EntityConfigurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies").HasKey(c => c.Id);
        // Sıralı Guid
        builder.Property(f => f.Id).ValueGeneratedOnAdd().HasValueGenerator<SequentialGuidValueGenerator>();
        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
        builder.Property(c => c.Email).HasColumnName("Email");
        builder.Property(c => c.MobilePhone).HasColumnName("MobilePhone");
        builder.Property(c => c.CompanyPhone).HasColumnName("CompanyPhone");
        builder.Property(c => c.StarRating).HasColumnName("StarRating");
        builder.Property(c => c.RatingCount).HasColumnName("RatingCount");
        builder.Property(c => c.AverageRating).HasColumnName("AverageRating");

        builder.Property(c => c.City).HasColumnName("City").IsRequired();
        builder.Property(c => c.District).HasColumnName("District").IsRequired();
        builder.Property(c => c.Neighborhood).HasColumnName("Neighborhood").IsRequired();
        builder.Property(c => c.Street).HasColumnName("Street").IsRequired();
        builder.Property(c => c.AddressDetail).HasColumnName("AddressDetail").IsRequired();
        builder.Property(c => c.MapUrl).HasColumnName("MapUrl").IsRequired();
        builder.Property(c => c.Location).HasColumnName("Location").HasColumnType("geography (point)").IsRequired(false);
        
        builder.Property(c => c.CompanyTypeName).HasColumnName("CompanyTypeName").IsRequired();
        builder.Property(c => c.CompanyTypeDescription).HasColumnName("CompanyTypeDescription").IsRequired();
        builder.Property(c => c.CompanyTypeImageUrl).HasColumnName("CompanyTypeImageUrl").IsRequired();

        builder.Property(c => c.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(c => c.IsDelete).HasColumnName("IsDelete").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasMany(c => c.CompanyUsers);
        builder.HasMany(c => c.Foods);        
        builder.HasMany(c => c.WorkingHours);

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}
