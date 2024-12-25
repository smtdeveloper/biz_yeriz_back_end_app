namespace bizYeriz.Domain.Entities.CompanyEntities;

public class CompanyUserToCompany
{
    public Guid CompanyUserId { get; set; }
    public Guid CompanyId { get; set; }

    public virtual CompanyUser CompanyUser { get; set; }
    public virtual Company Company { get; set; }

    public DateTime CreatedDate { get; set; }
}