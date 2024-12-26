﻿using bizYeriz.Domain.Entities.AuthEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace bizYeriz.Persistence.EntityConfigurations;
public class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
{
    public void Configure(EntityTypeBuilder<RefreshToken> builder)
    {
        builder.ToTable("RefreshTokens").HasKey(rt => rt.Id);
        builder.Property(rt => rt.Id).HasColumnName("Id").IsRequired();
        builder.Property(rt => rt.UserId).HasColumnName("UserId").IsRequired();
        builder.Property(rt => rt.Token).HasColumnName("Token").IsRequired();
        builder.Property(rt => rt.ExpirationDate).HasColumnName("ExpirationDate").IsRequired();
        builder.Property(rt => rt.CreatedByIp).HasColumnName("CreatedByIp").IsRequired();
        builder.Property(rt => rt.RevokedDate).HasColumnName("RevokedDate").IsRequired(false);
        builder.Property(rt => rt.RevokedByIp).HasColumnName("RevokedByIp").IsRequired(false);
        builder.Property(rt => rt.ReplacedByToken).HasColumnName("ReplacedByToken").IsRequired(false);
        builder.Property(rt => rt.ReasonRevoked).HasColumnName("ReasonRevoked").IsRequired(false);
        builder.Property(rt => rt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(rt => rt.UpdatedDate).HasColumnName("UpdatedDate").IsRequired(false);
        builder.Property(rt => rt.DeletedDate).HasColumnName("DeletedDate").IsRequired(false);

        builder.HasOne(rt => rt.User)
            .WithMany(u => u.RefreshTokens)
            .HasForeignKey(rt => rt.UserId)
            .IsRequired();
    }
}