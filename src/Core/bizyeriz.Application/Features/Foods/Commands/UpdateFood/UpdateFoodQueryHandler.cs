using AutoMapper;
using bizyeriz.Application.Features.Foods.BusinessRules;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;

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
        var company = await _foodRepository.GetByIdAsync(request.Id, cancellationToken);
        await _businessRules.CheckIfFoodIsNull(company);

        company = _mapper.Map(request, company);
        var updatedCompany = await _foodRepository.Update(company!);
        await _unitOfWork.CommitAsync();
        await _businessRules.CheckIfFoodIsNull(updatedCompany);

        UpdateFoodQueryResponse response = _mapper.Map<UpdateFoodQueryResponse>(company);
        return response;
    }
}
