using bizYeriz.Domain.Entities.CompanyEntities;
using bizYeriz.Domain.Entities.FoodEntities;
using bizYeriz.Domain.Entities.OrderEntities;
using Bogus;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
namespace bizYeriz.Persistence.EntityConfigurations;
public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies").HasKey(c => c.Id);
        builder.Property(f => f.Id).ValueGeneratedOnAdd().HasValueGenerator<SequentialGuidValueGenerator>();
        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
        builder.Property(c => c.Email).HasColumnName("Email").IsRequired(false);
        builder.Property(c => c.MobilePhone).HasColumnName("MobilePhone").IsRequired(false);
        builder.Property(c => c.CompanyPhone).HasColumnName("CompanyPhone").IsRequired();
        builder.Property(c => c.StarRating).HasColumnName("StarRating").IsRequired(false);
        builder.Property(c => c.RatingCount).HasColumnName("RatingCount").IsRequired(false);
        builder.Property(c => c.AverageRating).HasColumnName("AverageRating").IsRequired(false);
        builder.Property(c => c.City).HasColumnName("City").IsRequired(false);
        builder.Property(c => c.District).HasColumnName("District").IsRequired(false);
        builder.Property(c => c.Neighborhood).HasColumnName("Neighborhood").IsRequired(false);
        builder.Property(c => c.Street).HasColumnName("Street").IsRequired(false);
        builder.Property(c => c.AddressDetail).HasColumnName("AddressDetail").IsRequired(false);
        builder.Property(c => c.MapUrl).HasColumnName("MapUrl").IsRequired(false);
        builder.Property(c => c.Location).HasColumnName("Location").HasColumnType("geography (point)").IsRequired(false);
        builder.Property(c => c.CompanyTypeName).HasColumnName("CompanyTypeName").IsRequired(false);
        builder.Property(c => c.CompanyTypeDescription).HasColumnName("CompanyTypeDescription").IsRequired(false);
        builder.Property(c => c.CompanyTypeImageUrl).HasColumnName("CompanyTypeImageUrl").IsRequired(false);
        builder.Property(c => c.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(c => c.IsDelete).HasColumnName("IsDelete").IsRequired();
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate").IsRequired(false);
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate").IsRequired(false);
    }
}

public class MockData
{
    public static List<Company> GetMockCompanies()
    {
        var faker = new Faker();

        var companies = new List<Company>();

        for (int i = 0; i < 10; i++)
        {
            companies.Add(new Company
            {
                Id = Guid.NewGuid(),
                Name = faker.Company.CompanyName(),
                ImageUrl = faker.Image.PicsumUrl(),
                Email = faker.Internet.Email(),
                MobilePhone = faker.Phone.PhoneNumber(),
                CompanyPhone = faker.Phone.PhoneNumber(),
                StarRating = faker.Random.Double(1, 5),
                RatingCount = faker.Random.Double(10, 500),
                AverageRating = faker.Random.Double(1, 5),
                City = faker.Address.City(),
                District = faker.Address.SecondaryAddress(),
                Neighborhood = faker.Address.StreetName(),
                Street = faker.Address.StreetAddress(),
                AddressDetail = faker.Address.FullAddress(),
                MapUrl = faker.Internet.Url(),
                Location = null, // Add actual geography data if needed
                CompanyTypeName = faker.Commerce.Categories(1)[0],
                CompanyTypeDescription = faker.Lorem.Sentence(),
                CompanyTypeImageUrl = faker.Image.PicsumUrl(),
                IsActive = faker.Random.Bool(),
                IsDelete = false,
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                DeletedDate = null,
                EnvironmentallyFriendly = faker.Random.Bool(),
                IsTrustworthy = faker.Random.Bool(),
                Distance = "N/A", // You may add logic to calculate the distance
                CompanyUserToCompanies = new List<CompanyUserToCompany>(), // Add mock related entities
                FavoriteCompanies = new List<FavoriteCompany>(), // Add mock related entities
                Foods = new List<Food>(), // Add mock related entities
                WorkingHours = new List<CompanyWorkingHour>(), // Add mock related entities
                Orders = new List<Order>(), // Add mock related entities
                CompanyPaymentTypes = new List<CompanyPaymentType>(), // Add mock related entities
            });
        }
        return companies;
    }
}