namespace bizYeriz.Domain.Entities.CompanyEntities;

public class CompanyPaymentType : BaseEntity<int>
{
    public Guid CompanyId { get; set; }
    public int PaymentTypeId { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

    public virtual Company Company { get; set; }
    public virtual PaymentType PaymentType { get; set; }
}