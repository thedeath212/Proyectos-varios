using Microsoft.EntityFrameworkCore;
using WebMwcClinica.Models;
using WebMwcClinica.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BDClinicaContext>
   (options => options.UseSqlServer
   (builder.Configuration.GetConnectionString("Clinica"))
   );

builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".WebMwcClinica.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

//Agregar servicio
builder.Services.AddSession();

builder.Services.AddScoped<IServiceSpeciality, ServiceSpeciality>();


builder.Services.AddScoped<IServicePerson, ServicePerson>();



builder.Services.AddScoped<IServiceLogin, ServiceLogin>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
