using bizYeriz.Shared.Responses;

namespace bizyeriz.Application.Features.Foods.Queries.GetFoodById;

public record GetFoodByIdQuery(int Id) : IRequest<IDataResponse<GetFoodByIdQueryResponse>>;