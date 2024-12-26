namespace bizYeriz.Domain.Entities.CustomerEntities;
public class Customer : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }       
}