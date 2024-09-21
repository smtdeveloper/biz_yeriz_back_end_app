using bizYeriz.Domain.Entities.AuthEntities;
using Core.Security.Hashing;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizYeriz.Persistence.EntityConfigurations;
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {

        builder.ToTable("Users").HasKey(u => u.Id);
        // Sıralı Guid
        builder.Property(f => f.Id).ValueGeneratedOnAdd().HasValueGenerator<SequentialGuidValueGenerator>();

        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.Name).HasColumnName("Name").IsRequired();
        builder.Property(u => u.LastName).HasColumnName("LastName").IsRequired();
        builder.Property(u => u.Gsm).HasColumnName("Gsm");
        builder.Property(u => u.Email).HasColumnName("Email").IsRequired();
        builder.Property(u => u.BirthDate).HasColumnName("BirthDate");
        builder.Property(u => u.IsActive).HasColumnName("IsActive").IsRequired();
        builder.Property(u => u.IsDelete).HasColumnName("IsDelete").IsRequired();
        builder.Property(u => u.PasswordSalt).HasColumnName("PasswordSalt").IsRequired();
        builder.Property(u => u.PasswordHash).HasColumnName("PasswordHash").IsRequired();        
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

        //builder.HasMany(u => u.UserOperationClaims);
        //builder.HasMany(u => u.RefreshTokens);
        //builder.HasMany(u => u.EmailAuthenticators);
        //builder.HasMany(u => u.OtpAuthenticators);

        builder.HasData(_seeds);

        builder.HasBaseType((string)null!);
    }

    public static Guid AdminId { get; } = Guid.NewGuid();
    private IEnumerable<User> _seeds
    {
        get
        {
            HashingHelper.CreatePasswordHash(
                password: "codi",
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User adminUser =
                new()
                {
                    Id = AdminId,
                    Email = "codi@admin",
                    Name = "codi",
                    LastName = "coder",
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };
            yield return adminUser;
        }
    }
}
