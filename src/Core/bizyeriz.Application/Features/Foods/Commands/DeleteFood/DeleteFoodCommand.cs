namespace bizyeriz.Application.Features.Foods.Commands.DeleteFood;
public record DeleteFoodCommand(int Id) : IRequest<DeleteFoodCommandResponse>;
