using AgendaDeContatos.Data;
using AgendaDeContatos.Repositorio;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

//builder.Services.AddDbContext<BancoContext>(options
//    => options.UseMySql(ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DataBase"))));

builder.Services.AddDbContext<BancoContext>(options
    => options.UseMySql(builder.Configuration.GetConnectionString("DataBase"), ServerVersion.Parse("8.0.31")));

builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
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


app.Run();
