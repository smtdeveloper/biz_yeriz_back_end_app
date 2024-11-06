namespace bizyeriz.Application.Features.Foods.Queries.GetFoodById;

public record GetFoodByIdQuery(int Id) : IRequest<GetFoodByIdQueryResponse>;

