namespace bizyeriz.Application.Features.Companies.Queries.GetNearbyCompanies;

public class GetFilterNearbyCompaniesQueryResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = default!;
    public double Lat { get; set; }
    public double Long { get; set; }
    public double? Distance { get; set; }
    public string? ImageUrl { get; set; }
    public double StarRating { get; set; }
    public double RatingCount { get; set; }
    public double AverageRating { get; set; }
    public string CompanyTypeName { get; set; } = default!;
    public bool EnvironmentallyFriendly { get; set; }
    public bool IsTrustworthy { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

}
