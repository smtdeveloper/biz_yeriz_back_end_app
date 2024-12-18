using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Shared.Responses;

namespace bizyeriz.Application.Features.CuisineCategories.Queries.GetAllCuisineCategories;

public class GetAllCuisineCategoriesQueryHandler : IRequestHandler<GetAllCuisineCategoriesQuery, IDataResponse<List<GetAllCuisineCategoriesQueryResponse>>>
{
    private readonly ICuisineCategoryRepository _cuisineCategoryRepository;
    private readonly IMapper _mapper;
    public GetAllCuisineCategoriesQueryHandler(ICuisineCategoryRepository cuisineCategoryRepository, IMapper mapper)
    {
        _cuisineCategoryRepository = cuisineCategoryRepository;
        _mapper = mapper;   
    }

    public async Task<IDataResponse<List<GetAllCuisineCategoriesQueryResponse>>> Handle(GetAllCuisineCategoriesQuery request, CancellationToken cancellationToken)
    {
        var cuisineCategories = await _cuisineCategoryRepository.GetAllAsync(cancellationToken: cancellationToken);
        var response = _mapper.Map<List<GetAllCuisineCategoriesQueryResponse>>(cuisineCategories);
        var result = DataResponse<List<GetAllCuisineCategoriesQueryResponse>>.SuccessResponse(response, "Mutfaklar Başarıyla Listelendi.");
        return result;
    }

}