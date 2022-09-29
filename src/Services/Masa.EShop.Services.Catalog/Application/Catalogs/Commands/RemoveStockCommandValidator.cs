namespace Masa.EShop.Services.Catalog.Application.Catalogs.Commands;

public class RemoveStockCommandValidator : AbstractValidator<RemoveStockCommand>
{
    public RemoveStockCommandValidator()
    {
        RuleFor(cmd => cmd.OrderId).NotEqual(Guid.Empty).WithMessage("Wrong order Id");
        RuleFor(cmd => cmd.OrderStockItems).Must(items => items.Count() > 0).WithMessage("The items's count must greater than zero");
        //RuleForEach(cmd => cmd.OrderStockItems).SetValidator(new OrderStockItemValidator());
    }
}

public class OrderStockItemValidator : AbstractValidator<OrderStockItem>
{
    public OrderStockItemValidator()
    {
        RuleFor(cmd => cmd.ProductId).GreaterThan(0).WithMessage("Product does not exist");
        RuleFor(cmd => cmd.Units).GreaterThan(0).WithMessage("Item units desired should be greater than zero");
    }
}
