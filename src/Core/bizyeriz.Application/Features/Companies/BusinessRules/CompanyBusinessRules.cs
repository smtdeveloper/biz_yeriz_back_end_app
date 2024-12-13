using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Features.Companies.BusinessRules;

public class CompanyBusinessRules
{

    public async Task CheckIfCompanyIsNull(Company? company)
    {
        if (company == null)
        {
            throw new Exception("The company entity cannot be null.");
        }
    }


}

