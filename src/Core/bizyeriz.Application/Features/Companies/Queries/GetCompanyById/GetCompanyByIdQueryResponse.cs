using bizyeriz.Application.Features.Companies.Queries.GetAllFilters;

namespace bizyeriz.Application.Features.Companies.Queries.GetCompanyById;

public class GetCompanyByIdQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? ImageUrl { get; set; }
    public string Email { get; set; } = default!;
    public string MobilePhone { get; set; } = default!;
    public string CompanyPhone { get; set; } = default!;
    public double StarRating { get; set; }
    public double RatingCount { get; set; }
    public double AverageRating { get; set; }

    public string City { get; set; } = default!;
    public string District { get; set; } = default!;
    public string Neighborhood { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string AddressDetail { get; set; } = default!;
    public string MapUrl { get; set; } = default!;
    public double Lat { get; set; }
    public double Long { get; set; }


    public string CompanyTypeName { get; set; } = default!;
    public string CompanyTypeDescription { get; set; } = default!;
    public string? CompanyTypeImageUrl { get; set; }

    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

    public bool EnvironmentallyFriendly { get; set; }
    public bool IsTrustworthy { get; set; }
    public List<CuisineCategoryWithFoodsDto> CuisineCategoriesWithFoods { get; set; }
}

public class CompanyFoodsDto
{
    public Guid CompanyId { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public double OriginalPrice { get; set; }
    public double DiscountedPrice { get; set; }
    public DateTime AvailableFrom { get; set; }
    public DateTime AvailableUntil { get; set; }
    public int Stock { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }
   
}

public class CuisineCategoryWithFoodsDto
{
    public string CategoryName { get; set; }
    public List<CompanyFoodsDto> Foods { get; set; }
}
