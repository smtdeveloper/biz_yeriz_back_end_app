using bizYeriz.Domain.Entities.AuthEntities;
using bizYeriz.Domain.Entities.CompanyEntities;
using bizYeriz.Domain.Entities.CustomerEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace bizYeriz.Persistence.EntityConfigurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Tablo adı ve birincil anahtar
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);

        // Id alanı
        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd()
            .HasValueGenerator<SequentialGuidValueGenerator>()
            .HasColumnName("Id")
            .IsRequired();

        // RoleId alanı
        builder.Property(u => u.RoleId)
            .HasColumnName("RoleId")
            .IsRequired();

        // CompanyUserId ve CustomerId alanları
        builder.Property(u => u.CompanyUserId)
            .HasColumnName("CompanyUserId")
            .IsRequired(false);

        builder.Property(u => u.CustomerId)
            .HasColumnName("CustomerId")
            .IsRequired(false);

        // UserType alanı
        builder.Property(u => u.UserTypes)
            .HasColumnName("UserType")
            .IsRequired();

        // Email
        builder.Property(u => u.Email)
            .HasColumnName("Email")
            .HasMaxLength(255)
            .IsRequired(false);

        // PasswordHash
        builder.Property(u => u.PasswordHash)
            .HasColumnName("PasswordHash")
            .IsRequired();

        // İsim ve soyisim
        builder.Property(u => u.Name)
            .HasColumnName("Name")
            .IsRequired(false);

        builder.Property(u => u.LastName)
            .HasColumnName("LastName")
            .IsRequired(false);

        // GSM
        builder.Property(u => u.Gsm)
            .HasColumnName("Gsm")
            .HasMaxLength(20)
            .IsRequired(false);

        // Doğum tarihi
        builder.Property(u => u.BirthDate)
            .HasColumnName("BirthDate")
            .IsRequired(false);

        // Durum bilgileri
        builder.Property(u => u.IsActive)
            .HasColumnName("IsActive")
            .IsRequired();

        builder.Property(u => u.IsDelete)
            .HasColumnName("IsDelete")
            .IsRequired();

        // Tarih alanları
        builder.Property(u => u.CreatedDate)
            .HasColumnName("CreatedDate")
            .IsRequired();

        builder.Property(u => u.UpdatedDate)
            .HasColumnName("UpdatedDate")
            .IsRequired(false);

        builder.Property(u => u.DeletedDate)
            .HasColumnName("DeletedDate")
            .IsRequired(false);

        // Role ilişkisi
        builder.HasOne(u => u.Role)
            .WithMany(r => r.Users)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        // Customer ilişkisi
        builder.HasOne(u => u.Customer)
            .WithOne(c => c.User)
            .HasForeignKey<Customer>(c => c.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // CompanyUser ilişkisi
        builder.HasOne(u => u.CompanyUser)
            .WithOne(cu => cu.User)
            .HasForeignKey<CompanyUser>(cu => cu.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // RefreshToken ilişkisi
        builder.HasMany(u => u.RefreshTokens)
            .WithOne(rt => rt.User)
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Orders ile bire çok ilişki
        builder.HasMany(u => u.Orders)
               .WithOne(o => o.User)
               .HasForeignKey(o => o.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        // CompanyComment ile bire çok ilişki
        builder.HasMany(u => u.CompanyComments)
               .WithOne(cc => cc.User)
               .HasForeignKey(cc => cc.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        // FavoriteCompany ile bire çok ilişki
        builder.HasMany(u => u.FavoriteCompany)
               .WithOne(fc => fc.User)
               .HasForeignKey(fc => fc.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        // FavoriteFood ile bire çok ilişki
        builder.HasMany(u => u.FavoriteFood)
               .WithOne(ff => ff.User)
               .HasForeignKey(ff => ff.UserId)
               .OnDelete(DeleteBehavior.Restrict);

        // UserAddress ile bire çok ilişki
        builder.HasMany(u => u.UserAddresses)
               .WithOne(ua => ua.User)
               .HasForeignKey(ua => ua.UserId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}