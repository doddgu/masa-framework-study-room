namespace Masa.EShop.Services.Catalog.Infrastructure.EntityConfigurations;

class CatalogTypeEntityTypeConfiguration
    : IEntityTypeConfiguration<CatalogType>
{
    public void Configure(EntityTypeBuilder<CatalogType> builder)
    {
        builder.ToTable(nameof(CatalogType));
        
        builder.HasKey(ct => ct.Id);

        builder.Property(ct => ct.Id)
           .IsRequired();

        builder.Property(ct => ct.Type)
            .IsRequired()
            .HasMaxLength(100);
    }
}