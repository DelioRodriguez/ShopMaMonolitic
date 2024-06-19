using Microsoft.EntityFrameworkCore;
using ShopMaMonolitic.Data.Context;
using ShopMaMonolitic.Data.DbObjetcs;
using ShopMaMonolitic.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShopContext>(Options =>
    Options.UseSqlServer(builder.Configuration.GetConnectionString("ShopContext")));

//Agregar las dependencias del objeto de datos 
builder.Services.AddScoped<ISalesCustomersDb, SalesCustumersDb>();
builder.Services.AddScoped<ISalesOrdersDb, SalesOrdersDb>();
builder.Services.AddScoped<ISalesOrderDetailsDb, SalesOrdersDetailsDb>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) app.UseExceptionHandler("/Home/Error");
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();