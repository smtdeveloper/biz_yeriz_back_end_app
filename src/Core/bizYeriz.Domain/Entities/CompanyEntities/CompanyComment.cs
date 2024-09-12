namespace bizYeriz.Domain.Entities.CompanyEntities;

public class CompanyComment :  BaseEntity<int>
{
    public int OrderId { get; set; }
    public Guid CompanyId { get; set; }

    public string Contents { get; set; } = default!;
    public double StarRating { get; set; }
    public double RatingCount { get; set; }

    public bool Like { get; set; }
    public bool Dislike { get; set; }

    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

    public virtual Order Order { get; set; }
    public virtual Company  Company { get; set; }
}
