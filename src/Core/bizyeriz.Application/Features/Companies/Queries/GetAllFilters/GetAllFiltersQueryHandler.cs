using AutoMapper;
using bizyeriz.Application.Features.Companies.Enums;
using bizyeriz.Application.Features.Companies.Queries.GetAllFilters;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Shared.Responses;

public class GetAllFiltersQueryHandler : IRequestHandler<GetAllFiltersQuery, IDataResponse<GetAllFiltersQueryResponse>>
{
    private readonly ICuisineCategoryRepository _cuisineCategoryRepository;
    private readonly IMapper _mapper;

    public GetAllFiltersQueryHandler(ICuisineCategoryRepository cuisineCategoryRepository, IMapper mapper)
    {
        _cuisineCategoryRepository = cuisineCategoryRepository;
        _mapper = mapper;
    }

    public async Task<IDataResponse<GetAllFiltersQueryResponse>> Handle(GetAllFiltersQuery request, CancellationToken cancellationToken)
    {
        var cuisineCategoriesFromDb = await _cuisineCategoryRepository.GetAllAsync(cancellationToken: cancellationToken);
        var cuisineCategories = _mapper.Map<List<CuisineCategoryDto>>(cuisineCategoriesFromDb);

        var byPoints = StaticFilters.ByPoints
            .Select(bp => new ByPointDto { Id = bp.Id, Point = bp.Point, Name = bp.Name })
            .ToList();

        var priceRanges = StaticFilters.PriceRanges
            .Select(pr => new PriceRangeDto { Id = pr.Id, Range = pr.Range, Name = pr.Name })
            .ToList();

        var paymentTypes = StaticFilters.PaymentTypes
            .Select(pt => new PaymentTypeDto { Id = pt.Id, Name = pt.Name })
            .ToList();

        var orderTypes = StaticFilters.OrderTypes
            .Select(_orderTypes => new OrderTypeDto { Id = _orderTypes.Id, Name = _orderTypes.Name })
            .ToList();

        ByCuisineCategoryFilterModel cuisineCategoryFilterModel = new ByCuisineCategoryFilterModel
        { Data = cuisineCategories, FilterName = "Mutfaklar", IsMultiSelect = true };

        ByPointFilterModel byPointFilterModel = new ByPointFilterModel
        { Data = byPoints, FilterName = "Puanlar", IsMultiSelect = false };

        ByPaymentTypeFilterModel paymentTypeFilterModel = new ByPaymentTypeFilterModel
        { Data = paymentTypes, FilterName = "Ödeme Türleri", IsMultiSelect = true };

        ByPriceRangeFilterModel priceRangeFilterModel = new ByPriceRangeFilterModel
        { Data = priceRanges, FilterName = "Minimum Fiyat", IsMultiSelect = false };

        ByOrderFilterModel byOrderFilterModel = new ByOrderFilterModel
        { Data = orderTypes, FilterName = "Sıralamalar", IsMultiSelect = false };

        var response = new GetAllFiltersQueryResponse
        {
            ByCuisineCategory = cuisineCategoryFilterModel,
            ByPoint = byPointFilterModel,
            ByPriceRange = priceRangeFilterModel,
            ByPaymentType = paymentTypeFilterModel,
            ByOrder = byOrderFilterModel,
        };

        return DataResponse<GetAllFiltersQueryResponse>.SuccessResponse(response, "Tüm filterlar listelendi.");
    }
}