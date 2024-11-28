using AutoMapper;
using bizyeriz.Application.Features.Companies.Enums;
using bizyeriz.Application.Features.Companies.Queries.GetAllFilters;
using bizyeriz.Application.Interfaces.Repositories;

public class GetAllFiltersQueryHandler : IRequestHandler<GetAllFiltersQuery, GetAllFiltersQueryResponse>
{
    private readonly ICuisineCategoryRepository _cuisineCategoryRepository;
    private readonly IMapper _mapper;

    public GetAllFiltersQueryHandler(ICuisineCategoryRepository cuisineCategoryRepository, IMapper mapper)
    {
        _cuisineCategoryRepository = cuisineCategoryRepository;
        _mapper = mapper;
    }

    public async Task<GetAllFiltersQueryResponse> Handle(GetAllFiltersQuery request, CancellationToken cancellationToken)
    {
        var cuisineCategoriesFromDb = await _cuisineCategoryRepository.GetAllAsync(cancellationToken: cancellationToken);
        var cuisineCategories = _mapper.Map<List<CuisineCategoryDto>>(cuisineCategoriesFromDb);


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