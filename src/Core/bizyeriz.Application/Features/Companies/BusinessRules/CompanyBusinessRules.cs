using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.CompanyEntities;
using bizYeriz.Domain.Entities.FoodEntities;

namespace bizyeriz.Application.Features.Companies.BusinessRules;

public class CompanyBusinessRules
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyBusinessRules(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task CheckIfCompanyIsNull(Company company)
    {
        if (company == null)
        {
            throw new Exception("The company entity cannot be null.");
        }
    }


}

