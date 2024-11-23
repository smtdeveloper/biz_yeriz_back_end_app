namespace bizYeriz.Domain.Entities.FoodEntities;

public class Food : BaseEntity<int>
{
    public Guid CompanyId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public double OrjinalPrice { get; set; }
    public double DiscountedPrice { get; set; }
    public DateTime AvailableFrom { get; set; }
    public DateTime AvailableUntil { get; set; }
    public int Stock { get; set; }

    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

    public virtual ICollection<FoodCategoryAndFood> FoodCategoryAndFoods { get; set; }
    public virtual ICollection<CuisineCategoryAndFood>  CuisineCategoryAndFoods{ get; set; }

    public virtual Company Company { get; set; }

    public Food()
    {
        
    }

    public Food(int id, string name, bool isActive, bool ısDelete)
    {
        Id = id;
        Name = name;
        IsActive = isActive;
        IsDelete = ısDelete;
    }
}