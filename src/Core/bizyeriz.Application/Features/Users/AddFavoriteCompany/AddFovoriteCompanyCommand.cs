using bizyeriz.Application.Features.Companies.Commands.AddCompany;
using bizYeriz.Shared.Responses;
using System.Text.Json.Serialization;

namespace bizyeriz.Application.Features.Users.AddFavoriteCompany;

public class AddFovoriteCompanyCommand : IRequest<IResponse>
{
    //[JsonIgnore]
    public Guid UserId { get; set; }
    public Guid CompanyId { get; set; }
}