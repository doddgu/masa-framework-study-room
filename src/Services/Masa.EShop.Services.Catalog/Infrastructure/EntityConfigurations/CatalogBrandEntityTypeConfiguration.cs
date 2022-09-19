namespace Masa.EShop.Services.Catalog.Infrastructure.EntityConfigurations;

class CatalogBrandEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogBrand>
{
    public void Configure(EntityTypeBuilder<CatalogBrand> builder)
    {
        builder.ToTable(nameof(CatalogBrand));

        builder.HasKey(cb => cb.Id);

        builder.Property(cb => cb.Id)
           .IsRequired();

        builder.Property(cb => cb.Brand)
            .IsRequired()
            .HasMaxLength(100);
    }
}