
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using TKC_MDS.Data;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<MSD_Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddTransient<Dapper_Context>();
//var SalesDevConnectionString = builder.Configuration.GetConnectionString("SalDev");
//builder.Services.AddDbContext<SaleDev_Context>(options =>
//	options.UseSqlServer(SalesDevConnectionString));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDefaultIdentity<AppUser>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
})

    .AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<AppUser, Roles>>()
    .AddRoles<Roles>()
    .AddEntityFrameworkStores<MSD_Context>()
    //.AddDefaultUI()
    .AddDefaultTokenProviders();

//remove Antiforgery
builder.Services.AddAntiforgery(options => { options.Cookie.Expiration = TimeSpan.Zero; });

builder.Services.ConfigureApplicationCookie(option =>
{
    option.AccessDeniedPath = "/ErrorHandler/AccessDenied";
    option.LoginPath = "/user/Login";
	option.Cookie.HttpOnly = true;
	option.ExpireTimeSpan = TimeSpan.FromMinutes(60);
	// ReturnUrlParameter requires 
	//using Microsoft.AspNetCore.Authentication.Cookies;
	option.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
	option.SlidingExpiration = true;
});

//add log
var logger = Log.Logger = new LoggerConfiguration()
    //.WriteTo.Console()
	.WriteTo.File(Directory.GetCurrentDirectory()+"/logs/log-.txt", Serilog.Events.LogEventLevel.Verbose ,rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}")
	.CreateLogger();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    //The default HSTS value is 30 days.You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}");

app.Run();
