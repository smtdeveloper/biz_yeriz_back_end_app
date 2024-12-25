namespace bizYeriz.Domain.Entities.CompanyEntities;

public class PaymentType : BaseEntity<int>
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
    public virtual ICollection<CompanyPaymentType> CompanyPaymentTypes { get; set; } = new List<CompanyPaymentType>();
}