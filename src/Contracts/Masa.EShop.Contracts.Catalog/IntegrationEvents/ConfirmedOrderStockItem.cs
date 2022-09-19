namespace Masa.EShop.Contracts.Catalog.IntegrationEvents;

public record ConfirmedOrderStockItem(int ProductId, bool HasStock);