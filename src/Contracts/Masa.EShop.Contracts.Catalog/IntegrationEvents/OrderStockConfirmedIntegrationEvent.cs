namespace Masa.EShop.Contracts.Catalog.IntegrationEvents;

public record OrderStockConfirmedIntegrationEvent(Guid OrderId) : IntegrationEvent
{
    public override string Topic { get; set; } = nameof(OrderStockConfirmedIntegrationEvent);
}