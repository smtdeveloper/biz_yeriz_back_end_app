using bizYeriz.Shared.Responses;

namespace bizyeriz.Application.Features.Foods.Commands.DeleteFood;
public record DeleteFoodCommand(int Id) : IRequest<IResponse>;
