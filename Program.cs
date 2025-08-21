using Microsoft.EntityFrameworkCore;
using CineManager.Data;
using CineManager.Repositories;
using CineManager.Services;
using CineManager.Mapping;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ISucursalService, SucursalService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

builder.Services.AddScoped<IPeliculaService, PeliculaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ISalaService, SalaService>();
builder.Services.AddScoped<IFuncionService, FuncionService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();
if (!app.Environment.IsDevelopment()) { app.UseExceptionHandler("/Home/Error"); app.UseHsts(); }
app.UseHttpsRedirection(); app.UseStaticFiles(); app.UseRouting(); app.UseAuthorization();
app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
// filepath: c:\CAPACITACION\PROGRAMACIONORIENTAOBJETOS\CineManager_Full\CineManager\Program.cs
builder.Logging.AddDebug();
builder.Logging.AddConsole();
builder.Logging.SetMinimumLevel(LogLevel.Debug);
// ...existing code...

// ...existing code...

// ...existing code...
// ...existing code...
// ...existing code...