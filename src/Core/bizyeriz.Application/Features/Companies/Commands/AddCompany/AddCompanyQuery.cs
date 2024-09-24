namespace bizyeriz.Application.Features.Companies.Commands.AddCompany;

public class AddCompanyQuery : IRequest<AddCompanyQueryResponse>
{
    public string Name { get; set; } = default!;
    public string? ImageUrl { get; set; }
    public string Email { get; set; } = default!;
    public string MobilePhone { get; set; } = default!;
    public string CompanyPhone { get; set; } = default!;
    public double StarRating { get; set; }
    public double RatingCount { get; set; }

    public string City { get; set; } = default!;
    public string District { get; set; } = default!;
    public string Neighbarhood { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string AddreesDetail { get; set; } = default!;
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

}
