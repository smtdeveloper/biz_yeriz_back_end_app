namespace bizYeriz.Domain.Entities.CompanyEntities;

public class CompanyPoint : BaseEntity<int>
{
    public string Name { get; set; }
    public double MinimumPoint { get; set; }
}
