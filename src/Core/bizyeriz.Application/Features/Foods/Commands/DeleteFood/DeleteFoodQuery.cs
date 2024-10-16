namespace bizyeriz.Application.Features.Foods.Commands.DeleteFood;
public class DeleteFoodQuery : IRequest<DeleteFoodQueryResponse> 
{
    public int Id { get; set; }
}

