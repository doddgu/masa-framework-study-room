namespace Masa.EShop.Contracts.Ordering.IntegrationEvents;

public record OrderStatusChangedToPaidIntegrationEvent(
    Guid OrderId,
    string OrderStatus,
    string Description,
    string BuyerName,
    IEnumerable<OrderStockItem> OrderStockItems) : IntegrationEvent
{
    public override string Topic { get; set; } = nameof(OrderStatusChangedToPaidIntegrationEvent);
}