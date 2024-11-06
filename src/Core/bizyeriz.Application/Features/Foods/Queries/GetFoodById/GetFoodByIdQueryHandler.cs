
using AutoMapper;
using bizyeriz.Application.Features.Companies.Queries.GetCompanyById;
using bizyeriz.Application.Interfaces.Repositories;
using bizYeriz.Domain.Entities.CompanyEntities;

namespace bizyeriz.Application.Features.Foods.Queries.GetFoodById;

public class GetFoodByIdQueryHandler : IRequestHandler<GetFoodByIdQuery, GetFoodByIdQueryResponse>
{
    private readonly IFoodRepository _foodRepository; 
    private readonly IMapper _mapper;

    public GetFoodByIdQueryHandler(IFoodRepository foodRepository, IMapper mapper)
    {
        _foodRepository = foodRepository;
        _mapper = mapper;
    }

    public async Task<GetFoodByIdQueryResponse> Handle(GetFoodByIdQuery request, CancellationToken cancellationToken)
    {
        var food = await _foodRepository.GetByIdAsync(request.Id, cancellationToken);
        return _mapper.Map<GetFoodByIdQueryResponse>(food);
    }

}
