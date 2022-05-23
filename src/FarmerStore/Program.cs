using FarmerStore.Data;
using FarmerStore.Models;
using FarmerStore.Models.Products;
using FarmerStore.Models.Repositories;
using FarmerStore.Models.Validators;
using FarmerStore.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Agregar context
builder.Services.AddDbContext<FarmerStoreContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("FarmerStoreContext")));

//Injeccion de dependencias
builder.Services.AddScoped<IRepository, FarmerStoreSQL>();
builder.Services.AddScoped<UsersServices>();

//Configuracion autenticacion por cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Users/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.AccessDeniedPath = "/Users/Login";
    });


//Configurar validaciones para modelos
builder.Services.AddMvc().AddFluentValidation();
builder.Services.AddTransient<IValidator<Product>, ProductValidator>();

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
