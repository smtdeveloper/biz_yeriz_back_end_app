namespace bizyeriz.Application.Features.Companies.Models;

public class FilterCompaniesDto
{
    public List<int> CuisineCategoryIds { get; set; }
    public double? MinPrice { get; set; }
    public double? MaxPrice { get; set; }
}