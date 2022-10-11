using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMasaBlazor(builder =>
{
    builder.ConfigureTheme(theme =>
    {
        theme.Themes.Light.Primary = "#4318FF";
        theme.Themes.Light.Accent = "#4318FF";
    });
}).AddI18nForServer("wwwroot/i18n");
builder.Services.AddHttpContextAccessor();
builder.Services.AddGlobalForServer();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

builder.Services.AddAutoInject();
builder.Services.AddMapster();

#if DEBUG

builder.Services.AddDaprStarter(options =>
{
    options.AppIdSuffix = string.Empty;
    options.EnableSsl = null;
});

#endif

builder.Services.AddCaller(options =>
{
    options.UseDapr("CatalogCaller", clientBuilder =>
    {
        clientBuilder.AppId = "Masa-EShop-Services-Catalog";
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();