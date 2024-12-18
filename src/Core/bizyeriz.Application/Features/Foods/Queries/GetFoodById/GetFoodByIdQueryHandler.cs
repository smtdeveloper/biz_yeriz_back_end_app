using AutoMapper;
using bizyeriz.Application.Features.Foods.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Shared.Responses;

namespace bizyeriz.Application.Features.Foods.Queries.GetFoodById;

public class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, IDataResponse<GetFoodByIdQueryResponse>>
{
    private readonly IFoodRepository _foodRepository;
    private readonly IMapper _mapper;
    private readonly FoodBusinessRules _foodBusinessRules;

    public GetFoodByIdQueryHandler(IFoodRepository foodRepository, IMapper mapper, FoodBusinessRules foodBusinessRules)
    {
        _foodRepository = foodRepository;
        _mapper = mapper;
        _foodBusinessRules = foodBusinessRules;
    }

    public async Task<IDataResponse<GetFoodByIdQueryResponse>> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
    {
        var food = await _foodRepository.GetByIdAsync(request.Id, cancellationToken);
        await _foodBusinessRules.CheckIfFoodIsNull(food);
        GetFoodByIdQueryResponse response = _mapper.Map<GetFoodByIdQueryResponse>(food);
        var result = DataResponse<GetFoodByIdQueryResponse>.SuccessResponse(response, "Yemek Başarıyla Listelendi.");
        return result;
    }
}