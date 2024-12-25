using bizYeriz.Domain.Entities.CompanyEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bizYeriz.Persistence.EntityConfigurations;
public class CompanyCommentConfiguration : IEntityTypeConfiguration<CompanyComment>
{
    public void Configure(EntityTypeBuilder<CompanyComment> builder)
    {
        builder.ToTable("CompanyComments").HasKey(cc => cc.Id);

        // Property Configurations
        builder.Property(cc => cc.Id).HasColumnName("Id").IsRequired();
        builder.Property(cc => cc.OrderId).HasColumnName("OrderId").IsRequired();
        builder.Property(cc => cc.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(cc => cc.Contents).HasColumnName("Contents").IsRequired(false);
        builder.Property(cc => cc.StarRating).HasColumnName("StarRating").IsRequired();        
        builder.Property(cc => cc.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(cc => cc.IsDelete).HasColumnName("IsDelete").IsRequired();
        builder.Property(cc => cc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cc => cc.UpdatedDate).HasColumnName("UpdatedDate").IsRequired(false);
        builder.Property(cc => cc.DeletedDate).HasColumnName("DeletedDate").IsRequired(false);

        // Relationships
        builder.HasOne(cc => cc.Order)
               .WithOne(o => o.CompanyComment)
               .HasForeignKey<CompanyComment>(cc => cc.OrderId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(cc => cc.User)
               .WithMany(u => u.CompanyComments)
               .HasForeignKey(cc => cc.UserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}