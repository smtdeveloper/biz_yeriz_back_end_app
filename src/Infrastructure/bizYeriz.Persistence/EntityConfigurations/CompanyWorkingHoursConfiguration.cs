using bizYeriz.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;

public class CompanyWorkingHoursConfiguration : IEntityTypeConfiguration<CompanyWorkingHour>
{
    public void Configure(EntityTypeBuilder<CompanyWorkingHour> builder)
    {
        builder.ToTable("CompanyWorkingHours").HasKey(cwh => cwh.Id);

        builder.Property(cwh => cwh.Id).HasColumnName("Id").IsRequired();
        builder.Property(cwh => cwh.Day).HasColumnName("Day").IsRequired();
        builder.Property(cwh => cwh.OpenTime).HasColumnName("OpenTime").IsRequired();
        builder.Property(cwh => cwh.ClosingTime).HasColumnName("ClosingTime").IsRequired();
        builder.Property(cwh => cwh.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(cwh => cwh.IsDelete).HasColumnName("IsDelete").IsRequired();
        builder.Property(cwh => cwh.CompanyId).HasColumnName("CompanyId").IsRequired();
        builder.Property(cwh => cwh.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cwh => cwh.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cwh => cwh.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cwh => !cwh.DeletedDate.HasValue);
    }
}
