namespace bizYeriz.Domain.Entities.FoodEntities;

public class FavoriteFood : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public virtual User User { get; set; }

    public int FoodId { get; set; }
    public virtual Food Food { get; set; }

}