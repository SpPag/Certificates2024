using Certificates2024.Data;
using Certificates2024.Data.Services;
using Certificates2024.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Service Configuration
builder.Services.AddScoped<IQuestionsService, QuestionsService>();
builder.Services.AddScoped<ICertificateTopicsService, CertificateTopicsService>();
builder.Services.AddScoped<ICandidateCertificatesService, CandidateCertificatesService>();
builder.Services.AddScoped<ICandidatesService, CandidatesService>();

//Added this for testing purposes (recommended by our lord and savior ChatGPT). Leaving it as a comment for future reference
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
//           .EnableSensitiveDataLogging()
//           .LogTo(Console.WriteLine));
//builder.WebHost.UseEnvironment(Microsoft.Extensions.Hosting.Environments.Development);

//Authentication and authorization
builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

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
//Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//Seed database
AppDbInitializer.Seed(app);
AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
app.Run();
