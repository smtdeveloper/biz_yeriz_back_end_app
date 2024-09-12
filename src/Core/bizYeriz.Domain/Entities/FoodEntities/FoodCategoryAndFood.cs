namespace bizYeriz.Domain.Entities.FoodEntities;

public class FoodCategoryAndFood :BaseEntity<int>
{
    public int FoodCategoryId { get; set; }
    public int FoodId { get; set; }

    public virtual Food Food { get; set; }
    public virtual FoodCategory FoodCategory { get; set; }
}
