using bizYeriz.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;
public class CompanyCommentConfiguration : IEntityTypeConfiguration<CompanyComment>
{
    public void Configure(EntityTypeBuilder<CompanyComment> builder)
    {
        builder.ToTable("CompanyComments").HasKey(cc => cc.Id);

        builder.Property(cc => cc.Id).HasColumnName("Id").IsRequired();
        builder.Property(cc => cc.OrderId).HasColumnName("OrderId").IsRequired();
        builder.Property(cc => cc.Contents).HasColumnName("Contents").IsRequired();
        builder.Property(cc => cc.StarRating).HasColumnName("StarRating");
        builder.Property(cc => cc.RatingCount).HasColumnName("RatingCount");
        builder.Property(cc => cc.Like).HasColumnName("Like");
        builder.Property(cc => cc.Dislike).HasColumnName("Dislike");
        builder.Property(cc => cc.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(cc => cc.IsDelete).HasColumnName("IsDelete").IsRequired();
        builder.Property(cc => cc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cc => cc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cc => cc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cc => !cc.DeletedDate.HasValue);

        builder.HasOne(cc => cc.Order);
        builder.HasOne(cc => cc.Company);

    }
}