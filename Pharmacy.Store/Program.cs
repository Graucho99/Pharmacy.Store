using Microsoft.EntityFrameworkCore;
using Pharmacy.Store.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IMedicamentRepository, MedicamentRepository>();

builder.Services.AddDbContext<PharmacyStoreDbContext>
    (options => options.UseSqlServer(builder.Configuration["ConnectionStrings:PharmacyStoreDbContextConnection"]));

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapDefaultControllerRoute();

DbInitializer.Seed(app);

app.Run();
