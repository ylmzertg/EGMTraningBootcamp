using EGMTraning.Data.DataContext;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using EGMTraning.UI.Extentions;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using EGMTraning.BusinessEngine.Contracts;
using EGMTraning.UI.Helpers;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
//TODO:builder ile bareber servıslerımızı eklıyruz.
// Add services to the container.
//builder.Services.AddControllersWithViews(opt =>
//{
//    opt.Filters.Add(new MySampleFilterAttribute());
//}).AddRazorRuntimeCompilation();
builder.Services.AddSession(opt => 
{
    opt.IdleTimeout = TimeSpan.FromMinutes(5);
});
builder.Services.AddDbContext<EmployeeDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("CustomConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(EmployeeDbContext)).GetName().Name);
    });
});

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
});

//builder.Services.AddScoped<IWorkOrderBusinessEngine, WorkOrderBusinessEngine>();
//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddApplicationServices();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath="/login";
        options.AccessDeniedPath="/denied";
        options.Events= new CookieAuthenticationEvents()
        {
            OnSigningIn = async context =>
            {
                var principal = context.Principal;
                if (principal.HasClaim(x => x.Type == ClaimTypes.NameIdentifier))
                {
                    if (principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value=="Ertuğ")
                    {
                        var claimIdentity = principal.Identity as ClaimsIdentity;
                        claimIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));
                    }
                }
                await Task.CompletedTask;
            },
            OnSignedIn = async context =>
            {
                await Task.CompletedTask;
            },
            OnValidatePrincipal = async context =>
            {
                await Task.CompletedTask;
            }
        };
    });

builder.Services.AddLocalization();

#region LanguageConfiguration

var serviceProvider = builder.Services.BuildServiceProvider();

var lang = serviceProvider.GetService<ILanguageBusinessEngine>();
var result = serviceProvider.GetService<IStringResourceBusinessEngine>();
LangHelper.Test(lang,result);

var languageService = serviceProvider.GetRequiredService<ILanguageBusinessEngine>();
var languages= languageService.GetLanguages();
var culture = languages.Result.Data.Select(x=> new CultureInfo(x.Culture)).ToArray();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var englishCulture = culture.FirstOrDefault(x => x.Name =="en-US");
    options.DefaultRequestCulture= new Microsoft.AspNetCore.Localization.RequestCulture(englishCulture?.Name ?? "en-US");
    options.SupportedCultures= culture;
    options.SupportedUICultures= culture;
});

#endregion



var app = builder.Build();


//-----------------------------------------------//
//TODO:Servislerin kullanılıcagı ve ara katmanlarımızın kodlarını eklıyoruz.(Middleware)
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    //app.UseDeveloperExceptionPage();
    app.UseHsts();
}
else
{
    //app.UseExceptionHandler(errorApp =>
    //{
    //    errorApp.Run(async context =>
    //    {
    //        context.Response.StatusCode = 500;
    //        context.Response.ContentType ="text/html";

    //        await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
    //        await context.Response.WriteAsync("Error! <br> <br> \r \n");

    //        var expectionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
    //        //if (expectionHandlerPathFeature?.Error is FileNotFoundException)
    //        //    await context.Response.WriteAsync("File error thrown! <br> <br> \r \n");
    //        await context.Response.WriteAsync("<a href=\"/\">Home</a> \r \n");
    //        await context.Response.WriteAsync("</body> </html> \r \n");
    //        await context.Response.WriteAsync(new string(' ', 512));
    //    });
    //});
}

//app.UseStatusCodePages();
//app.UseStatusCodePages("text/plain","Status code pages custom , status code : {0}");
//app.UseStatusCodePagesWithRedirects("/Error/Index?code={0}");



app.UseRequestLocalization();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
