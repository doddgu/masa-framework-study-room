namespace Masa.EShop.Services.Catalog.Application.Catalogs.Commands;

public class StockValidationCommandValidator : AbstractValidator<StockValidationCommand>
{
    public StockValidationCommandValidator()
    {
        RuleFor(cmd => cmd.OrderId).NotEqual(Guid.Empty).WithMessage("Wrong order Id");
        RuleFor(cmd => cmd.OrderStockItems).Must(items => items.Count() > 0).WithMessage("The items's count must greater than zero");
        //RuleForEach(cmd => cmd.OrderStockItems).SetValidator(new OrderStockItemValidator());
    }
}
