using bizYeriz.Domain.Enums;

namespace bizYeriz.Domain.Entities.OrderEntities;

public class OrderStatue : BaseEntity<int>
{
    public OrderStatusType OrderStatus { get; set; }
    public string Excuse { get; set; } = string.Empty;
}
