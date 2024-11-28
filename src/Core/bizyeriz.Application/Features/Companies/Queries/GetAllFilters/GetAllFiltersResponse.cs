namespace bizyeriz.Application.Features.Companies.Queries.GetAllFilters;

public class GetAllFiltersResponse
{
    public List<CuisineCategoryDto> CuisineCategories { get; set; }
    public List<PaymentTypeDto> PaymentTypes { get; set; }
    public List<PriceRangeDto> PriceRanges { get; set; }
    public List<ByPointDto> ByPoints { get; set; }
}

public class CuisineCategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; }    
}

public class PaymentTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class PriceRangeDto
{
    public int Id { get; set; }
    public double Range { get; set; }
}
public class ByPointDto
{
    public int Id { get; set; }
    public double Point { get; set; }
}