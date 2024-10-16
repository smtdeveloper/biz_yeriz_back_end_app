using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;

namespace bizyeriz.Application.Features.Foods.Commands.DeleteFood;

public class DeleteFoodQueryHandler : IRequestHandler<DeleteFoodQuery, DeleteFoodQueryResponse>
{
    private readonly IFoodRepository _foodRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public DeleteFoodQueryHandler(IFoodRepository foodRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _foodRepository = foodRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<DeleteFoodQueryResponse> Handle(DeleteFoodQuery request, CancellationToken cancellationToken)
    {
        var food = await _foodRepository.GetByIdAsync(request.Id, cancellationToken);
        _foodRepository.Remove(food);
        await _unitOfWork.CommitAsync();

        DeleteFoodQueryResponse response = _mapper.Map<DeleteFoodQueryResponse>(food);
        return response;
    }

}
