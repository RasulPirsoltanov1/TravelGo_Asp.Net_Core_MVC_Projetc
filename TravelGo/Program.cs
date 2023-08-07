using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.Contexts;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Serilog;
using TravelGo.Mapping;
using TravelGo.Models.CustomIdentityValidator;
using BusinessLayer.Registrations;
using BusinessLayer.CQRS.Results.GuideResults;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using BusinessLayer.CQRS.Queries.Destinations;
using BusinessLayer.CQRS.Queries.GuideQueries;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<Context>()
    .AddErrorDescriber<CustomIdentityValidator>();

builder.Services.ContainerDependencies();

builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console().WriteTo.File("wwwroot/logs/log.txt").WriteTo.MSSqlServer(@"Server=DESKTOP-UGCLLOE\\MSSQLSERVER2;Database=TravelGoDB;integrated security=true;", "Logs", autoCreateSqlTable: true).MinimumLevel.Error()
    .ReadFrom.Configuration(builder.Configuration));


builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddMvc();
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(105);

    options.LoginPath = "/Login/SignIn";
    options.AccessDeniedPath = "/Account/Login";
    options.SlidingExpiration = true;
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddHttpClient();

builder.Services.AddServiceRegistration();




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
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");
app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
   );


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Run();
