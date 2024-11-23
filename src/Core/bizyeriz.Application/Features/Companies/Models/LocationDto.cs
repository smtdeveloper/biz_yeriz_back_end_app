using System.Text.Json.Serialization;

namespace bizyeriz.Application.Features.Companies.Models;

public class LocationDto
{   
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Distance { get; set; }
}