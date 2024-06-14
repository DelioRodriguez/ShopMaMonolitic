using Microsoft.EntityFrameworkCore;
using ShopMaMonolitic.BL.Interfaces;
using ShopMaMonolitic.BL.Services;
using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.DbObjects;
using ShopMaMonolitic.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShopContext>(options => 
 options.UseSqlServer(builder.Configuration.GetConnectionString("ShopContext")));

//Agregar las dependencias del objeto de datos //
builder.Services.AddScoped<IProductionCategoriesDb, ProductionCategoriesDb>();


//Agregar las dependencias del BL //
builder.Services.AddTransient<IProductionCategoriesService,ProductionCategoriesService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();