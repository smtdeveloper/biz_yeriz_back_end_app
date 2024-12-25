namespace bizYeriz.Domain.Entities.CompanyEntities;

public  class CompanyComment :  BaseEntity<int>
{
    public Guid UserId { get; set; }
    public int OrderId { get; set; }
   
    public string? Contents { get; set; }
    public double StarRating { get; set; }     
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

    public virtual Order Order { get; set; }   
    public virtual User  User { get; set; }   
}