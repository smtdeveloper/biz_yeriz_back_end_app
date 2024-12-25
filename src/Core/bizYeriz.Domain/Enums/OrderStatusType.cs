namespace bizYeriz.Domain.Enums;

public enum OrderStatusType
{
    None = 0,
    Pending =1,
    Preparing =2,
    OutForDelivery = 3,
    ReadyForPickup = 4,
    Delivered = 5,
    Cancelled = 6
}