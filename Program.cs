using Barinak.Data;
using Barinak.Data.Abstract;
using Barinak.Data.Concrete;
using Barinak.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BarinakContext>(options => { options.UseSqlite(builder.Configuration["ConnectionStrings:sql_connection"]); });

builder.Services.AddScoped<IAnimalRepository, EfAnimalRepository>();
builder.Services.AddScoped<IBreedRepository, EfBreedRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

SeedData.TestVerileriniDoldur(app);

app.MapControllerRoute(
    name: "animals_details",
    pattern: "animals/details/{url}",
    defaults: new { controller = "Animals", action = "Details" }
);

app.MapControllerRoute(
    name: "breeds_list",
    pattern: "animals/breed/{breed}",
    defaults: new { controller = "Animals", action = "Index" }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Animals}/{action=Index}/{id?}"
);

app.Run();
