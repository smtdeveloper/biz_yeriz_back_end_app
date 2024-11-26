namespace bizYeriz.Domain.Entities.CompanyEntities
{
    public class CompanyPaymentType 
    {
        public Guid CompanyId { get; set; }
        public int PaymentTypeId { get; set; }

        public virtual Company Company { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }

}