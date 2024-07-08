using AYStore.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddRazorPages();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IShoppingCart, ShoppingCart>(ShoppingCart.GetCart);

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddDbContext<AYStoreDbContext>(options =>
        options.UseSqlServer(builder.Configuration["ConnectionStrings:AYStoreDbConnection"]));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
app.MapRazorPages();

DbInitializer.Seed(app);

app.Run();
