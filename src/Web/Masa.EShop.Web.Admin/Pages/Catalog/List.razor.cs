using Masa.BuildingBlocks.Service.Caller;
using Masa.EShop.Web.Admin.Pages.App.User;

namespace Masa.EShop.Web.Admin.Pages.Catalog
{
    public partial class List
    {
        private PaginatedResultDto<CatalogListItemDto> _result = default!;
        private List<CatalogListItemViewModel> _data = default!;
        private List<int> _pageSizes = new() { 10, 25, 50, 100 };
        private int _pageIndex = 0;
        private int _selectedPageSize = 10;
        private string _search = string.Empty;
        private bool _showEditor = false;
        private List<DataTableHeader<CatalogListItemViewModel>> _headers = default!;
        private List<dynamic> _catalogTypes = default!;
        private List<dynamic> _catalogBrands = default!;

        [Inject]
        private ICaller Caller { get; set; } = default!;

        protected async override Task OnInitializedAsync()
        {
            _headers = new()
            {
                new() { Text = T("Name"), Value = nameof(CatalogListItemViewModel.Name) },
                new() { Text = T("Picture"), Value = nameof(CatalogListItemViewModel.PictureFileName) },
                new() { Text = T("Type"), Value = nameof(CatalogListItemViewModel.CatalogTypeName) },
                new() { Text = T("Catalog.Brand"), Value = nameof(CatalogListItemViewModel.CatalogBrandName) },
                new() { Text = T("Price"), Value = nameof(CatalogListItemViewModel.Price) },
                new() { Text = T("Catalog.AvailableStock"), Value = nameof(CatalogListItemViewModel.AvailableStock) },
                new() { Text = T("Action"), Value = "Action", Sortable = false }
            };

            _catalogTypes = (await Caller.GetAsync<List<dynamic>>("/api/v1/catalogs/Types"))!;

            _catalogBrands = (await Caller.GetAsync<List<dynamic>>("/api/v1/catalogs/Brands"))!;

            await Refresh();

            await base.OnInitializedAsync();
        }

        private async Task Refresh()
        {
            await Search(_pageIndex);
        }

        private async Task Search(int pageIndex)
        {
            _result = (await Caller.GetAsync<PaginatedResultDto<CatalogListItemDto>>("/api/v1/catalogs/Items", new
            {
                TypeId = 0,
                BrandId = 0,
                PageIndex = pageIndex,
                PageSize = _selectedPageSize
            }))!;

            _data = _result.Result.Select(dto => new CatalogListItemViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                AvailableStock = dto.AvailableStock,
                CatalogBrandId = dto.CatalogBrandId,
                CatalogTypeId = dto.CatalogTypeId,
                PictureFileName = dto.PictureFileName,
                Price = dto.Price,
                //todo dynamic
                CatalogBrandName = _catalogBrands.First(b => b.id == dto.CatalogBrandId),
                CatalogTypeName = _catalogTypes.First(t => t.id == dto.CatalogTypeId),
            }).ToList();
        }

        private void ShowEditor(int id)
        {
            _showEditor = true;
            
            
        }

        private async Task AddProductAsync(AddProductViewModel vm)
        {
            try
            {
                _ = await Caller.PostAsync("/api/v1/catalogs/product", vm);

                await PopupService.AlertAsync(T("Saved"), AlertTypes.Success);

                await Refresh();
            }
            catch (Exception ex)
            {
                await PopupService.AlertAsync(ex.Message, AlertTypes.Error);
            }
        }
    }
}
