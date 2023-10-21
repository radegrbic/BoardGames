using DomainServices;
using IdentityDataLayer;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PlayerBoardGameNightDataLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services
    .AddScoped<IPlayerDAO, SQLPlayerDAO>()

    .AddDbContext<PlayerBoardGameNightDbContext>(options =>
    {
        options
                .UseSqlServer(builder.Configuration["ConnectionStrings:BoardGamesConnectionString"])
                .EnableSensitiveDataLogging(true);
    })

    .AddDbContext<SecurityDbContext>(options =>
    {
        options
                .UseSqlServer(builder.Configuration["ConnectionStrings:BoardGamesSecurityConnectionString"])
                .EnableSensitiveDataLogging(true);
    })
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<SecurityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthorization(policyBuilder =>
{
    policyBuilder.AddPolicy("Organisor", policy =>
    {
        policy.RequireAuthenticatedUser()
              .RequireClaim("UserType", "organisor");
    });
    policyBuilder.AddPolicy("Player", policy =>
    {
        policy.RequireAuthenticatedUser()
              .RequireClaim("UserType", "player");
    });

});

builder.Services
    .Configure<AntiforgeryOptions>(opts =>
    {
        opts.HeaderName = "X-XSRF-TOKEN";
    })
    .Configure<CookiePolicyOptions>(options =>
    {
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
    });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1);
    options.Cookie.IsEssential = false;
});



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCookiePolicy();

app.UseSession();

IAntiforgery antiforgery = app.Services.GetRequiredService<IAntiforgery>();
app.Use(async (context, next) =>
{
    if (!context.Request.Path.StartsWithSegments("/api"))
    {
        string? token = antiforgery.GetAndStoreTokens(context).RequestToken;
        if (token != null)
        {
            context.Response.Cookies.Append("XSRF-TOKEN", token, new CookieOptions { HttpOnly = false });
        }
    }
    await next();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "login",
    pattern: "Account/Login",
    defaults: new { Controller = "Account", action = "Login" }
);

app.MapDefaultControllerRoute();

app.Run();

