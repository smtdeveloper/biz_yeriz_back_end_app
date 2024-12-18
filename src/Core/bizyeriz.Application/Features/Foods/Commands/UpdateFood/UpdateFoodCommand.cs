using bizyeriz.Application.Features.Companies.Commands.UpdateCompany;
using bizYeriz.Shared.Responses;

namespace bizyeriz.Application.Features.Foods.Commands.UpdateFood;

public class UpdateFoodCommand : IRequest<IResponse>
{
    public Guid CompanyId { get; set; }

    public int Id{ get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public double OriginalPrice { get; set; }
    public double DiscountedPrice { get; set; }
    public DateTime AvailableFrom { get; set; }
    public DateTime AvailableUntil { get; set; }
    public int Stock { get; set; }

}
