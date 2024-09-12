

namespace bizYeriz.Domain.Entities.CustomerEntities;

public class Customer : BaseEntity<Guid>
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    public virtual ICollection<Food> FavoriteFood { get; set; }
    public virtual ICollection<Company> FavoriteCompany { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}
