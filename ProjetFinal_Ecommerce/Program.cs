using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjetFinal_Ecommerce.Database;
using ProjetFinal_Ecommerce.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Db_CommerceContext_Connection") ?? throw new InvalidOperationException("Connection string 'Db_CommerceContext_Connection' not found.");;

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Db_CommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Db_CommerceContext_Connection"]);
});

builder.Services.AddScoped<IProduitRepository, Db_ProduitRepository>();
builder.Services.AddScoped<IFactureRepository, Db_FactureRepository>();

// Services utilisateurs & rôles
builder.Services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Db_CommerceContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddSession();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Authentification et autorisations
app.UseAuthentication();
app.UseAuthorization();

// Utilisation de la session

app.UseSession();


// Les pages pour les users
app.MapRazorPages();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Utilisateur}/{action=Index}/{id?}")
    .WithStaticAssets();

// Seeder pour les tables de l'application
await Db_Seeder.Seed(app);
app.Run();
