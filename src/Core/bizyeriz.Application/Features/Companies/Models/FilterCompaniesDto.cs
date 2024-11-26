using bizyeriz.Application.Features.Companies.Enums;

namespace bizyeriz.Application.Features.Companies.Models;

public class FilterCompaniesDto
{
    public List<int> CuisineCategoryIds { get; set; }   
    public PriceRange? PriceRange { get; set; }
}