namespace bizyeriz.Application.Features.Companies.Models;

public class FilterCompaniesDto
{
    public List<int>? CuisineCategoryIds { get; set; } = new List<int>();
    public int? PriceRangeId { get; set; }
    public int? ByPointId { get; set; }
    public int? ByOrderId { get; set; }
    public List<int>? PaymentIds { get; set; } = new List<int>();
}