namespace bizYeriz.Domain.Entities.OrderEntities;

public class Order : BaseEntity<int>
{
    public Guid CustomerId { get; set; }
    public Guid CompanyId { get; set; }
    public Guid CompanyCommentId { get; set; }
    public Guid CustomerAddressId { get; set; }

    public string OrderStatus { get; set; } = default!; //Enum
    public decimal TotalAmount { get; set; }
    public string PaymentMethod { get; set; } = default!; //Enum
    public bool IsPaid { get; set; }
    public decimal? Discount { get; set; }
    public decimal TaxAmount { get; set; }
    public decimal? ShippingCost { get; set; }
    public string Notes { get; set; } = default!;
    public string TrackingNumber { get; set; } = default!;
    public string CouponCode { get; set; } = default!;

    public DateTime OrderDate { get; set; }
    public DateTime? DeliveryDate { get; set; }
    public DateTime? CancelledDate { get; set; }
    public decimal? RefundAmount { get; set; }

    ICollection<OrderItem> OrderItems { get; set; }

    public Customer Customer { get; set; }
    public Company Company { get; set; }
    public CompanyComment CompanyComment { get; set; }
    public CustomerAddress CustomerAddress { get; set; }

    public DeliveryType DeliveryType { get; set; } //Enum
}
