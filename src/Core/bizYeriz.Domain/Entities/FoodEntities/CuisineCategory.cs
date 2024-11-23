namespace bizYeriz.Domain.Entities.FoodEntities;

public class CuisineCategory : BaseEntity<int>
{   
    public string CategoryName { get; set; }
    public string ImageUrl { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

    public virtual ICollection<CuisineCategoryAndFood> CuisineCategoryAndFoods { get; set; }
}