using bizYeriz.Domain.Entities.FoodEntities;

namespace bizYeriz.Domain.Entities.OrderEntities
{
    internal class OrderItem : BaseEntity<int>
    {
        public int OrderId { get; set; }
        public int FoodId { get; set; }
        public int Quantity { get; set; }
        public string FoodName { get; set; } = default!;
        public string FoodImageUrl { get; set; } = default!;
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public Order Order { get; set; }
        public Food Food { get; set; }
    }
}
