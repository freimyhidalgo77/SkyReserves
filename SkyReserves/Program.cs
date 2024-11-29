using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SkyReserves.Components;
using SkyReserves.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Inyeccion del contexto
var ConStr = builder.Configuration.GetConnectionString("SqlConStr");
builder.Services.AddDbContextFactory<Context>(o => o.UseSqlServer(ConStr));

builder.Services.AddScoped<AccesibilidadService>();
builder.Services.AddScoped<AsientoService>();
builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<ClaseVueloService>();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<NacionalidadService>();
builder.Services.AddScoped<OrigenService>();
builder.Services.AddScoped<DestinoService>();
builder.Services.AddScoped<PagoService>();
builder.Services.AddScoped<HoraService>();
builder.Services.AddScoped<PasaporteService>();
builder.Services.AddScoped<PasaporteDetalleService>();
builder.Services.AddScoped<ReservaService>();
builder.Services.AddScoped<VuelosEspecialesService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/Login";
        options.AccessDeniedPath = "/access-denied";
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();