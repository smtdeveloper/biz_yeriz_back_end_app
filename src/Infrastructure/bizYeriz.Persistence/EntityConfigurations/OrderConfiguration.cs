using bizYeriz.Domain.Entities.OrderEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasOne(o => o.CompanyComment)
            .WithOne(c => c.Order)
            .HasForeignKey<Order>(o => o.CompanyCommentId);  // Order entity'si bağımlı taraf olarak belirlendi
    }
}
