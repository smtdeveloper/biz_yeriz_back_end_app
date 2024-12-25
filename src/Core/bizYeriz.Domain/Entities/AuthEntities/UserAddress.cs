namespace bizYeriz.Domain.Entities.AuthEntities;

public class UserAddress : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public string CustomerAddressName { get; set; } = default!;
    public string City { get; set; } = default!;
    public string District { get; set; } = default!;
    public string Neighbarhood { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string AddreesDetail { get; set; } = default!;
    public string Lat { get; set; } = default!;
    public string Long { get; set; } = default!;
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

    ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual User User { get; set; }
}