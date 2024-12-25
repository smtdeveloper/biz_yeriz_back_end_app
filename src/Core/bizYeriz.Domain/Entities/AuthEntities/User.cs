namespace bizYeriz.Domain.Entities.AuthEntities;

public class User : BaseEntity<Guid>
{
    public Guid RoleId { get; set; }
    public Guid? CompanyUserId { get; set; }
    public Guid? CustomerId { get; set; }
    public UserTypes UserTypes { get; set; }
    public string? Email { get; set; }
    public string PasswordHash { get; set; }  
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Gsm { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

    public virtual Role Role { get; set; }  
    public virtual Customer? Customer { get; set; }
    public virtual CompanyUser? CompanyUser { get; set; }
     
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    public virtual ICollection<CompanyComment> CompanyComments { get; set; } = new List<CompanyComment>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<FavoriteCompany> FavoriteCompany { get; set; } = new List<FavoriteCompany>();
    public virtual ICollection<FavoriteFood> FavoriteFood { get; set; } = new List<FavoriteFood>();
    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();
}