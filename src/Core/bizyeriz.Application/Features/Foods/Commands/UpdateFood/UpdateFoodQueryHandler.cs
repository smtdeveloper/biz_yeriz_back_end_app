using AutoMapper;
using bizyeriz.Application.Features.Foods.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizYeriz.Domain.Entities.FoodEntities;

namespace bizyeriz.Application.Features.Foods.Commands.UpdateFood;

public class UpdateFoodQueryHandler : IRequestHandler<UpdateFoodQuery, UpdateFoodQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IFoodRepository _foodRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly FoodBusinessRules _businessRules;

    public UpdateFoodQueryHandler(IMapper mapper, IFoodRepository foodRepository, IUnitOfWork unitOfWork, FoodBusinessRules businessRules)
    {
        _mapper = mapper;
        _foodRepository = foodRepository;
        _unitOfWork = unitOfWork;
        _businessRules = businessRules;
    }

    public async Task<UpdateFoodQueryResponse> Handle(UpdateFoodQuery request, CancellationToken cancellationToken)
    {
        Food food = await _foodRepository.GetByIdAsync(request.Id, cancellationToken);
        await _businessRules.CheckIfFoodIsNull(food);
        food = _mapper.Map(request, food);
        Food updatedCompany = await _foodRepository.Update(food!);
        await _unitOfWork.CommitAsync();
        await _businessRules.CheckIfFoodIsNull(updatedCompany);
        UpdateFoodQueryResponse response = _mapper.Map<UpdateFoodQueryResponse>(food);
        return response;
    }
}
