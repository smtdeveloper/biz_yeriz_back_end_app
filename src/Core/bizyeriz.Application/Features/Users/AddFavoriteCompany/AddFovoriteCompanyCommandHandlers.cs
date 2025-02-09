using AutoMapper;
using bizyeriz.Application.Interfaces.Repositories;
using bizyeriz.Application.Interfaces.UnitOfWork;
using bizYeriz.Domain.Entities.CompanyEntities;
using bizYeriz.Shared.Responses;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace bizyeriz.Application.Features.Users.AddFavoriteCompany;

public class AddFovoriteCompanyCommandHandlers : IRequestHandler<AddFovoriteCompanyCommand, IResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    public AddFovoriteCompanyCommandHandlers
        (IUnitOfWork unitOfWork, 
        IMapper mapper, 
        IUserRepository userRepository)        
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<IResponse> Handle(AddFovoriteCompanyCommand command, CancellationToken cancellationToken)
    {
        FavoriteCompany favoriteCompany = new FavoriteCompany { UserId = command.UserId, CompanyId = command.CompanyId, CreatedDate = DateTime.UtcNow };
        bool addedCompany = await _userRepository.AddFovoriteCompanyAsync(favoriteCompany, cancellationToken);

        if (!addedCompany)
            return Response.FailureResponse("Şirket favorilere eklenemedi.");

        try
        {
            await _unitOfWork.CommitAsync();
        }
        catch (Exception ex)
        {
            throw;
        }


        var result = Response.SuccessResponse("Şirket Başarıyla fovorilere Eklendi.");
        return result;    
    }
}