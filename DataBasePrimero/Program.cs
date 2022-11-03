using DataBasePrimero;
using EntityBasicoDAL;
using EntityBasicoDAL.Modelo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<entityBasicoContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("EFCConexion"))
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//METODO PARA INSERCION
app.Seed();
app.Run();
