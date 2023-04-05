using EGMTraning.UI.ActionFilters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
//TODO:builder ile bareber servıslerımızı eklıyruz.
// Add services to the container.
//builder.Services.AddControllersWithViews(opt =>
//{
//    opt.Filters.Add(new MySampleFilterAttribute());
//}).AddRazorRuntimeCompilation();

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
});


var app = builder.Build();


//-----------------------------------------------//
//TODO:Servislerin kullanılıcagı ve ara katmanlarımızın kodlarını eklıyoruz.(Middleware)
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
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
app.UseStatusCodePagesWithRedirects("/Error/Index?code={0}");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
