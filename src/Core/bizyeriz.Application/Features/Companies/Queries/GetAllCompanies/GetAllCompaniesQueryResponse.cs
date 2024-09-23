namespace bizyeriz.Application.Features.Companies.Queries.GetAllCompanies;

public class GetAllCompaniesQueryResponse
{

    public string Name { get; set; } = default!;
    public string? ImageUrl { get; set; }
    public double StarRating { get; set; }
    public double RatingCount { get; set; }

    public string CompanyTypeName { get; set; } = default!;
  
    public bool EnvironmentallyFriendly { get; set; }
    public bool IsTrustworthy { get; set; }

}
