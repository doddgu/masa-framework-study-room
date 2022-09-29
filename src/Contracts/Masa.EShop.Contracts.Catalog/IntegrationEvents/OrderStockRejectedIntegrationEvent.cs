namespace Masa.EShop.Contracts.Catalog.IntegrationEvents;

public record OrderStockRejectedIntegrationEvent(
    Guid OrderId,
    List<ConfirmedOrderStockItem> OrderStockItems) : IntegrationEvent
{
    public override string Topic { get; set; } = nameof(OrderStockRejectedIntegrationEvent);
}