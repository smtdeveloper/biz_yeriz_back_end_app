using bizYeriz.Domain.Entities.CustomerEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace bizYeriz.Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        // Tablo adı ve birincil anahtar tanımı
        builder.ToTable("Customers").HasKey(c => c.Id);

        // Sıralı Guid için yapılandırma
        builder.Property(c => c.Id)
               .ValueGeneratedOnAdd()
               .HasValueGenerator<SequentialGuidValueGenerator>()
               .HasColumnName("Id")
               .IsRequired();

        // Kolon isimlendirmesi ve zorunlu alanlar
        builder.Property(c => c.UserId)
               .HasColumnName("UserId")
               .IsRequired();

        builder.Property(c => c.CreatedDate)
               .HasColumnName("CreatedDate")
               .IsRequired();

        builder.Property(c => c.UpdatedDate)
               .HasColumnName("UpdatedDate")
               .IsRequired(false);

        builder.Property(c => c.DeletedDate)
               .HasColumnName("DeletedDate")
               .IsRequired(false);

        // Yumuşak silme için sorgu filtresi
        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);

        // User ile birebir ilişki
        builder.HasOne(c => c.User)
               .WithOne(u => u.Customer)
               .HasForeignKey<Customer>(c => c.UserId)
               .OnDelete(DeleteBehavior.Cascade);

    }
}