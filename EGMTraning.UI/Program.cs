using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
//TODO:builder ile bareber servıslerımızı eklıyruz.
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
});


var app = builder.Build();


//-----------------------------------------------//
//TODO:Servislerin kullanılıcagı ve ara katmanlarımızın kodlarını eklıyoruz.(Middleware)
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseDeveloperExceptionPage();

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
