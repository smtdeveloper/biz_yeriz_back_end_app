namespace bizyeriz.Application.Features.Foods.Commands.DeleteFood;
public record DeleteFoodQuery(int Id) : IRequest<DeleteFoodQueryResponse>;
