namespace bizyeriz.Application.Features.Companies.Queries.GetAllFilters;

public class GetAllFiltersQueryResponse
{
    public CuisineCategoryFilterModel ByCuisineCategory { get; set; }
    public PaymentTypeFilterModel ByPaymentType { get; set; }
    public PriceRangeFilterModel ByPriceRange { get; set; }
    public ByPointFilterModel ByPoint { get; set; }
}

public class PaymentTypeFilterModel 
{
    public string FilterName { get; set; }
    public bool IsMultiSelect { get; set; }
    public List<PaymentTypeDto> Data { get; set; }
}

public class CuisineCategoryFilterModel
{
    public string FilterName { get; set; }
    public bool IsMultiSelect { get; set; }
    public List<CuisineCategoryDto> Data { get; set; }
}

public class PriceRangeFilterModel 
{
    public string FilterName { get; set; }
    public bool IsMultiSelect { get; set; }
    public List<PriceRangeDto> Data { get; set; }

}

public class ByPointFilterModel 
{
    public string FilterName { get; set; }
    public bool IsMultiSelect { get; set; }
    public List<ByPointDto> Data { get; set; }
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
    public string Name { get; set; }
}
public class ByPointDto
{
    public int Id { get; set; }
    public double Point { get; set; }
    public string Name { get; set; }
}