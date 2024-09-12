namespace bizYeriz.Domain.Entities.FoodEntities;

public class FoodCategory : BaseEntity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int OrderNumber { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

    public virtual ICollection<FoodCategoryAndFood> FoodCategoryAndFoods { get; set; }

}
