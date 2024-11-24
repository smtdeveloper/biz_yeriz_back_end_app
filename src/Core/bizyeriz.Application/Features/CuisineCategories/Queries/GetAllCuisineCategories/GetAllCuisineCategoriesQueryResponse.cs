namespace bizyeriz.Application.Features.CuisineCategories.Queries.GetAllCuisineCategories;

public class GetAllCuisineCategoriesQueryResponse
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string ImageUrl { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
}
