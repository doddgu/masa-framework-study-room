using Masa.BuildingBlocks.Service.Caller;
using Masa.EShop.Web.Admin.Pages.App.User;
using Masa.EShop.Web.Admin.Pages.Catalog.Service;
using System.Dynamic;

namespace Masa.EShop.Web.Admin.Pages.Catalog
{
    public partial class List
    {
        #region Fields & Members

        private PaginatedResultDto<CatalogListItemDto> _result = default!;
        private List<CatalogListItemViewModel> _data = default!;
        private List<DataTableHeader<CatalogListItemViewModel>> _headers = default!;
        private List<int> _pageSizes = new() { 10, 25, 50, 100 };
        private int _page = 1;
        private int _pageSize = 10;
        private int _typeId = 0;
        private int _brandId = 0;
        private bool _showEditor = false;
        private List<CatalogTypeDto> _catalogTypes = default!;
        private List<CatalogBrandDto> _catalogBrands = default!;

        private int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                Page = 1;
            }
        }

        private int Page
        {
            get { return _page; }
            set
            {
                _page = value;
                InvokeAsync(Search);
            }
        }

        private int TypeId
        {
            get { return _typeId; }
            set
            {
                _typeId = value;
                Page = 1;
            }
        }

        private int BrandId
        {
            get { return _brandId; }
            set
            {
                _brandId = value;
                Page = 1;
            }
        }

        #endregion

        [Inject]
        private CatalogSericeCaller Caller { get; set; } = default!;

        protected override Task OnParametersSetAsync()
        {
            _headers = new()
            {
                new() { Text = T("Name"), Value = nameof(CatalogListItemViewModel.Name) },
                new() { Text = T("Catalog.Picture"), Value = nameof(CatalogListItemViewModel.PictureFileName) },
                new() { Text = T("Type"), Value = nameof(CatalogListItemViewModel.CatalogTypeName) },
                new() { Text = T("Catalog.Brand"), Value = nameof(CatalogListItemViewModel.CatalogBrandName) },
                new() { Text = T("Price"), Value = nameof(CatalogListItemViewModel.Price) },
                new() { Text = T("Catalog.AvailableStock"), Value = nameof(CatalogListItemViewModel.AvailableStock) },
                new() { Text = T("Action"), Value = "Action", Sortable = false }
            };

            return base.OnParametersSetAsync();
        }

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                _catalogTypes = await Caller.GetTypesAsync();

                _catalogBrands = await Caller.GetBrandsAsync();

                await Search();
            }

            await base.OnAfterRenderAsync(firstRender);
        }

        private async Task Search()
        {
            _result = await Caller.GetItemsAsync(Page, PageSize, TypeId, BrandId);

            _data = _result.Result.Select(dto => new CatalogListItemViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                AvailableStock = dto.AvailableStock,
                CatalogBrandId = dto.CatalogBrandId,
                CatalogTypeId = dto.CatalogTypeId,
                PictureFileName = dto.PictureFileName,
                Price = dto.Price,
                CatalogBrandName = _catalogBrands.First(b => b.Id == dto.CatalogBrandId).Brand,
                CatalogTypeName = _catalogTypes.First(t => t.Id == dto.CatalogTypeId).Type,
            }).ToList();

            StateHasChanged();
        }

        private void ShowEditor(int id)
        {
            _showEditor = true;
            
            
        }

        private async Task AddProductAsync(AddProductViewModel vm)
        {
            try
            {
                await Caller.AddProductAsync(vm);

                await PopupService.AlertAsync(T("Saved"), AlertTypes.Success);

                await Search();
            }
            catch (Exception ex)
            {
                await PopupService.AlertAsync(ex.Message, AlertTypes.Error);
            }
        }
    }
}
