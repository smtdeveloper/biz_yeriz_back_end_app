using bizyeriz.Application.Features.Companies.Enums;
using bizyeriz.Application.Features.Companies.Queries.GetAllFilters;
using System.Threading;
using System.Threading.Tasks;

public class GetAllFiltersQueryHandler : IRequestHandler<GetAllFiltersQuery, GetAllFiltersQueryResponse>
{
    public async Task<GetAllFiltersQueryResponse> Handle(GetAllFiltersQuery request, CancellationToken cancellationToken)
    {
        // StaticFilters'dan sabit değerleri al
        var cuisineCategories = StaticFilters.CuisineCategories
            .Select(c => new CuisineCategoryDto { Id = c.Id, Name = c.Name })
            .ToList();

        var byPoints = StaticFilters.ByPoints
            .Select(bp => new ByPointDto { Id = bp.Id, Point = bp.Point})
            .ToList();

        var priceRanges = StaticFilters.PriceRanges
            .Select(pr => new PriceRangeDto { Id = pr.Id, Range = pr.Range})
            .ToList();

        var paymentTypes = StaticFilters.PaymentTypes
            .Select(pt => new PaymentTypeDto { Id = pt.Id, Name = pt.Name })
            .ToList();

        // Sabit değerlerin birleştirilmesi
        return await Task.FromResult(new GetAllFiltersQueryResponse
        {
            CuisineCategories = cuisineCategories,
            ByPoints = byPoints,
            PriceRanges = priceRanges,
            PaymentTypes = paymentTypes
        });
    }
}
