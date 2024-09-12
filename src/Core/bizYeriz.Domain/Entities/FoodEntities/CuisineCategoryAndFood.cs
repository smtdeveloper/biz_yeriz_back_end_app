namespace bizYeriz.Domain.Entities.FoodEntities;

public class CuisineCategoryAndFood : BaseEntity<int>
{
    public int CuisineCategoryId { get; set; }
    public int FoodId { get; set; }

    public virtual CuisineCategory CuisineCategory { get; set; }
    public virtual Food Food { get; set; }
}
