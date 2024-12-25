namespace bizYeriz.Domain.Entities.FoodEntities;

public class Food : BaseEntity<int>
{
    public Guid CompanyId { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public double? OriginalPrice { get; set; }
    public double? DiscountedPrice { get; set; }
    public DateTime? AvailableFrom { get; set; }
    public DateTime? AvailableUntil { get; set; }
    public int? Stock { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public virtual ICollection<FavoriteFood> FavoriteFood { get; set; } = new List<FavoriteFood>();
    public virtual ICollection<FoodCategoryAndFood> FoodCategoryAndFoods { get; set; } = new List<FoodCategoryAndFood>();
    public virtual ICollection<CuisineCategoryAndFood> CuisineCategoryAndFoods { get; set; } = new List<CuisineCategoryAndFood>();

    public virtual Company Company { get; set; }
}