namespace bizyeriz.Application.Features.Foods.Queries.GetAllFoods;

public class GetAllFoodsQueryResponse
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

}
