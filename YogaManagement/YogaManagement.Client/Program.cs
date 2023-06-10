using Microsoft.AspNetCore.Authentication.Cookies;
using Refit;
using YogaManagement.Client.OdataClient.Default;
using YogaManagement.Client.RefitClient;
using YogaManagement.Database.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.LoginPath = "/Auth/AccessDenied";
        opt.AccessDeniedPath = "/Auth/AccessDenied";
    });

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.MaxValue;
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
var cntString = configuration.GetConnectionString("YogaManagement");
var odataRoot = configuration.GetConnectionString("Odata");
builder.Services.AddScoped(x => new Container(new Uri(odataRoot + "/")));
builder.Services.AddSqlServer<YogaManagementDbContext>(cntString);

string baseUrl = odataRoot;
builder.Services.AddRefitClient<IAuthorityClient>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(baseUrl));

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.AddMvcCore()
    .AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
