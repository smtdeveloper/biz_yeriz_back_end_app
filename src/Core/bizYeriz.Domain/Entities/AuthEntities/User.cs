namespace bizYeriz.Domain.Entities.AuthEntities;

public class User : BaseEntity<Guid>
{
    public string Email { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string? Gsm { get; set; }
    public DateTime? BirthDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

    public UserType UserType { get; set; }

    public virtual Customer Customer { get; set; }
    public virtual CompanyUser CompanyUser { get; set; }
}
