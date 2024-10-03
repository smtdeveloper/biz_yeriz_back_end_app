namespace bizyeriz.Application.Features.Companies.Commands.UpdateCompany;

public class UpdateCompanyQueryResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? ImageUrl { get; set; }
    public string Email { get; set; }
    public string MobilePhone { get; set; }
    public string CompanyPhone { get; set; }

    public string City { get; set; }
    public string District { get; set; }
    public string Neighborhood { get; set; }
    public string Street { get; set; }
    public string AddressDetail { get; set; }
    public string MapUrl { get; set; }
    public double Lat { get; set; }
    public double Long { get; set; }

    public string CompanyTypeName { get; set; }
    public string CompanyTypeDescription { get; set; }
    public string? CompanyTypeImageUrl { get; set; }

    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

    public bool EnvironmentallyFriendly { get; set; } = false;
    public bool IsTrustworthy { get; set; } = false;
}
