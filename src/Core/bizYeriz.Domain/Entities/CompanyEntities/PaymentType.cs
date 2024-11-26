namespace bizYeriz.Domain.Entities.CompanyEntities;

public class PaymentType : BaseEntity<int>
{
    public string Name { get; set; }
    public virtual ICollection<CompanyPaymentType> CompanyPaymentTypes { get; set; }
}