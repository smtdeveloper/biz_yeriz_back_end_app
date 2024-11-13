using AutoMapper;
using bizyeriz.Application.Features.Foods.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;

namespace bizyeriz.Application.Features.Foods.Commands.DeleteFood;

public class DeleteFoodCommandHandler : IRequestHandler<DeleteFoodCommand, DeleteFoodCommandResponse>
{
    private readonly IFoodRepository _foodRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly FoodBusinessRules _foodBusinessRules;

    public DeleteFoodCommandHandler(IFoodRepository foodRepository, IMapper mapper, IUnitOfWork unitOfWork, FoodBusinessRules foodBusinessRules)
    {
        _foodRepository = foodRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _foodBusinessRules = foodBusinessRules;
    }

    public async Task<DeleteFoodCommandResponse> Handle(DeleteFoodCommand request, CancellationToken cancellationToken)
    {
        var food = await _foodRepository.GetByIdAsync(request.Id, cancellationToken);
        _foodBusinessRules.CheckIfFoodIsNull(food);
        _foodRepository.Remove(food);
        await _unitOfWork.CommitAsync();
        DeleteFoodCommandResponse response = _mapper.Map<DeleteFoodCommandResponse>(food);
        return response;
    }

}
