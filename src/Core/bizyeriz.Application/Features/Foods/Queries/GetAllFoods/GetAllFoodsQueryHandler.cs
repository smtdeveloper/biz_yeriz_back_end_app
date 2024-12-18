using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Shared.Responses;

namespace bizyeriz.Application.Features.Foods.Queries.GetAllFoods;

public class GetAllFoodsQueryHandler : IRequestHandler<GetAllFoodsQuery, IDataResponse<List<GetAllFoodsQueryResponse>>>
{
    private readonly IFoodRepository _foodRepository;
    private readonly IMapper _mapper;
    public GetAllFoodsQueryHandler(IFoodRepository foodRepository, IMapper mapper)
    {
        _foodRepository = foodRepository;
        _mapper = mapper;
    }

    public async Task<IDataResponse<List<GetAllFoodsQueryResponse>>> Handle(GetAllFoodsQuery request, CancellationToken cancellationToken)
    {
        var foods = await _foodRepository.GetAllAsync<GetAllFoodsQueryResponse>(cancellationToken);
        var response = _mapper.Map<List<GetAllFoodsQueryResponse>>(foods);
        var result = DataResponse<List<GetAllFoodsQueryResponse>>.SuccessResponse(response, "Yemekler Başarıyla Listelendi.");
        return result;
    }

}
