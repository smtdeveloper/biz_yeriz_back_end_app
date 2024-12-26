namespace bizYeriz.Domain.Entities.OrderEntities;
public class Order : BaseEntity<int>
{
    public Guid UserId { get; set; }
    public Guid CompanyId { get; set; }
    public int CompanyCommentId { get; set; }
    public OrderStatusType OrderStatus { get; set; }
    public string Excuse { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public string PaymentMethod { get; set; } = default!; //Enum
    public bool IsPaid { get; set; }
    public decimal? Discount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal? ShippingCost { get; set; }
    public string Notes { get; set; } = default!;
    public string TrackingNumber { get; set; } = default!;
    public string CouponCode { get; set; } = default!;
    public DeliveryType DeliveryType { get; set; } //Enum
    public DateTime OrderDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public DateTime? CancelledDate { get; set; }
    public decimal? RefundAmount { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public User User{ get; set; }
    public Company Company { get; set; }
    public CompanyComment CompanyComment { get; set; }
   
}