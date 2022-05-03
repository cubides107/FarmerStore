using FarmerStore.Data;
using FarmerStore.Models.Entities;
using FarmerStore.Models.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Agregar context
builder.Services.AddDbContext<FarmerStoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FarmerStoreContext")));

//Injeccion de dependencias
builder.Services.AddScoped<IRepository, FarmerStoreSQL>();

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
