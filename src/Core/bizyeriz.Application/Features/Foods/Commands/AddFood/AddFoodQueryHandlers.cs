using AutoMapper;
using bizyeriz.Application.Features.Companies.BusinessRules;
using bizyeriz.Application.Features.Foods.BusinessRules;
using bizyeriz.Application.Features.Foods.Commands.AddCompany;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizYeriz.Domain.Entities.FoodEntities;

namespace bizyeriz.Application.Features.Foods.Commands.AddFood;

public class AddFoodQueryHandlers : IRequestHandler<AddFoodQuery, AddFoodQueryResponse>
{
    private readonly IMapper _mapper;
    private readonly IFoodRepository _foodRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly FoodBusinessRules _businessRules;

    public AddFoodQueryHandlers(IMapper mapper, IFoodRepository foodRepository, IUnitOfWork unitOfWork, FoodBusinessRules businessRules)
    {
        _mapper = mapper;
        _foodRepository = foodRepository;
        _unitOfWork = unitOfWork;
        _businessRules = businessRules;
    }


    public async Task<AddFoodQueryResponse> Handle(AddFoodQuery request, CancellationToken cancellationToken)
    {
        Food food = _mapper.Map<Food>(request);
        await _businessRules.CheckIfFoodIsNull(food);

        food.CreatedDate = DateTime.UtcNow;
        var addedCompany = await _foodRepository.AddAsync(food, cancellationToken);
        await _unitOfWork.CommitAsync();

        AddFoodQueryResponse response = _mapper.Map<AddFoodQueryResponse>(addedCompany);
        return response;
    }


}
