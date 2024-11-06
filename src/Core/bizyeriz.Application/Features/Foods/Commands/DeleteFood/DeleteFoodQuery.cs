namespace bizyeriz.Application.Features.Foods.Commands.DeleteFood;
public record DeleteFoodQuery(int id) : IRequest<DeleteFoodQueryResponse>;

