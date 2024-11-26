namespace bizYeriz.Domain.Entities.CompanyEntities;

public class MinOrderAmount : BaseEntity<int>
{
    public string Name { get; set; }
    public double Amount { get; set; }
}