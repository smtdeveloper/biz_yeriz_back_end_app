namespace bizyeriz.Application.Features.Foods.Queries.GetFoodById;

public class GetFoodByIdQueryResponse
{
    public int Id { get; set; }
    public Guid CompanyId { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public double OrjinalPrice { get; set; }
    public double DiscountedPrice { get; set; }
    public DateTime AvailableFrom { get; set; }
    public DateTime AvailableUntil { get; set; }
    public int Stock { get; set; }
    
}
