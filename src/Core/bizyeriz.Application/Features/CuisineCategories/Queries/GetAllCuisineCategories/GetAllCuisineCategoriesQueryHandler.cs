
using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;

namespace bizyeriz.Application.Features.CuisineCategories.Queries.GetAllCuisineCategories;

public class GetAllCuisineCategoriesQueryHandler : IRequestHandler<GetAllCuisineCategoriesQuery, List<GetAllCuisineCategoriesQueryResponse>>
{
    private readonly ICuisineCategoryRepository _cuisineCategoryRepository;
    private readonly IMapper _mapper;
    public GetAllCuisineCategoriesQueryHandler(ICuisineCategoryRepository cuisineCategoryRepository, IMapper mapper)
    {
        _cuisineCategoryRepository = cuisineCategoryRepository;
        _mapper = mapper;   
    }

    public async Task<List<GetAllCuisineCategoriesQueryResponse>> Handle(GetAllCuisineCategoriesQuery request, CancellationToken cancellationToken)
    {
        var cuisineCategories = await _cuisineCategoryRepository.GetAllAsync(cancellationToken: cancellationToken);
        var result = _mapper.Map<List<GetAllCuisineCategoriesQueryResponse>>(cuisineCategories);
        return result;
    }

}