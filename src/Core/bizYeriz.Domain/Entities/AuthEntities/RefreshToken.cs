namespace bizYeriz.Domain.Entities.AuthEntities;

public class RefreshToken : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public string Token { get; set; }
    public DateTime ExpirationDate { get; set; }
    public string CreatedByIp { get; set; }
    public DateTime? RevokedDate { get; set; }
    public string? RevokedByIp { get; set; }
    public string? ReplacedByToken { get; set; }
    public string? ReasonRevoked { get; set; }

    public virtual User User { get; set; } = default!;
}