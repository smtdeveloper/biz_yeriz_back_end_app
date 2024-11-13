using AutoMapper;
using bizyeriz.Application.Features.Foods.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizYeriz.Domain.Entities.FoodEntities;

namespace bizyeriz.Application.Features.Foods.Commands.UpdateFood;

public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand, UpdateFoodCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IFoodRepository _foodRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly FoodBusinessRules _businessRules;

    public UpdateFoodCommandHandler(IMapper mapper, IFoodRepository foodRepository, IUnitOfWork unitOfWork, FoodBusinessRules businessRules)
    {
        _mapper = mapper;
        _foodRepository = foodRepository;
        _unitOfWork = unitOfWork;
        _businessRules = businessRules;
    }

    public async Task<UpdateFoodCommandResponse> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
    {
        Food food = await _foodRepository.GetByIdAsync(request.Id, cancellationToken);
        await _businessRules.CheckIfFoodIsNull(food);
        food = _mapper.Map(request, food);
        Food updatedCompany = await _foodRepository.Update(food!);
        await _unitOfWork.CommitAsync();
        await _businessRules.CheckIfFoodIsNull(updatedCompany);
        UpdateFoodCommandResponse response = _mapper.Map<UpdateFoodCommandResponse>(food);
        return response;
    }
}
