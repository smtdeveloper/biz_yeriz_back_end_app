namespace bizYeriz.Domain.Entities.CompanyEntities;

public class CompanyUser : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public Guid CompanyId { get; set; }

    public virtual User User { get; set; }
    public virtual Company Company { get; set; }
}
