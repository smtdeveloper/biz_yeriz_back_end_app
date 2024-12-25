namespace bizYeriz.Domain.Entities.CompanyEntities;

public class FavoriteCompany : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public Guid CompanyId { get; set; }
    public virtual Company Company{ get; set; }

}