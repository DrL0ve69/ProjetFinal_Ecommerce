using Microsoft.EntityFrameworkCore;
using ProjetFinal_Ecommerce.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Db_CommerceContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:Db_CommerceContext_Connection"]);
});
builder.Services.AddScoped<IProduitRepository, Db_ProduitRepository>();

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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Produits}/{action=Index}/{id?}")
    .WithStaticAssets();

Db_Seeder.Seed(app);
app.Run();
