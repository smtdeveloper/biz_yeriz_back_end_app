
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations.Schema;

namespace bizYeriz.Domain.Entities.CompanyEntities;

public class Company : BaseEntity<Guid>
{
    public string Name { get; set; } = default!;
    public string? ImageUrl { get; set; }
    public string Email { get; set; } = default!;
    public string MobilePhone { get; set; } = default!;
    public string CompanyPhone { get; set; } = default!;
    public double? StarRating { get; set; }
    public double? RatingCount { get; set; }
    public double? AverageRating { get; set; }
    public string City { get; set; } = default!;
    public string District { get; set; } = default!;
    public string Neighborhood { get; set; } = default!;
    public string Street { get; set; } = default!;
    public string AddressDetail { get; set; } = default!;
    public string MapUrl { get; set; } = default!;    
    public Point? Location { get; set; }   
    public string CompanyTypeName { get; set; } = default!;
    public string CompanyTypeDescription { get; set; } = default!;
    public string? CompanyTypeImageUrl { get; set; }

    public bool IsActive { get; set; }
    public bool IsDelete { get; set; }

    public bool EnvironmentallyFriendly { get; set; }
    public bool IsTrustworthy { get; set; }

    [NotMapped]
    public string Distance { get; set; }

    public virtual ICollection<CompanyUserToCompany> CompanyUserToCompanies { get; set; } = new List<CompanyUserToCompany>();
    public virtual ICollection<FavoriteCompany> FavoriteCompanies { get; set; } = new List<FavoriteCompany>();
    public virtual ICollection<Food> Foods { get; set; } = new List<Food>();
    public virtual ICollection<CompanyWorkingHour> WorkingHours { get; set; } = new List<CompanyWorkingHour>();
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual ICollection<CompanyPaymentType> CompanyPaymentTypes { get; set; } = new List<CompanyPaymentType>();
}