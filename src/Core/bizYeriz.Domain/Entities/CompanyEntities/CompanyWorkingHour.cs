namespace bizYeriz.Domain.Entities.CompanyEntities;

public class CompanyWorkingHour : BaseEntity<int>
{
    public DayOfWeek Day { get; set; }
    public TimeSpan OpenTime { get; set; }
    public TimeSpan ClosingTime { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

    public Guid CompanyId { get; set; }
    public virtual Company Company { get; set; }
}
