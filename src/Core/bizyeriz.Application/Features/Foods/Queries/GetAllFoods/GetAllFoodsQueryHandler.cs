using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.FoodEntities;

namespace bizyeriz.Application.Features.Foods.Queries.GetAllFoods;

public class GetAllFoodsQueryHandler : IRequestHandler<GetAllFoodsQuery, List<GetAllFoodsQueryResponse>>
{
    private readonly IFoodRepository _foodRepository;
    private readonly IMapper _mapper;
    public GetAllFoodsQueryHandler(IFoodRepository foodRepository, IMapper mapper)
    {
        _foodRepository = foodRepository;
        _mapper = mapper;
    }

    public async Task<List<GetAllFoodsQueryResponse>> Handle(GetAllFoodsQuery request, CancellationToken cancellationToken)
    {
        var foods = await _foodRepository.GetAllAsync<GetAllFoodsQueryResponse>(cancellationToken);
        var result = _mapper.Map<List<GetAllFoodsQueryResponse>>(foods);
        return result;
    }

}
