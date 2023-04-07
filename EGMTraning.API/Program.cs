using EGMTraning.BusinessEngine.Contracts;
using EGMTraning.BusinessEngine.Implementation;
using EGMTraning.Data.DataContext;
using EGMTraning.Data.DataContracts;
using EGMTraning.Data.Implementation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EmployeeDbContext>(x =>
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("CustomConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(EmployeeDbContext)).GetName().Name);
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IWorkOrderBusinessEngine, WorkOrderBusinessEngine>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                          .AddJwtBearer(options =>
                          {
                              options.RequireHttpsMetadata = false;
                              options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                              {
                                  //TODO:kim tarafından oluşturuluyor.
                                  ValidIssuer="http:localhost",
                                  //TODO:kım tarafından kullanılacak
                                  ValidAudience ="http:localhost",
                                  //TODO:Signature
                                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EgmTraningSecon2")),
                                  ValidateIssuerSigningKey = true,
                                  //TODO:yeni oluşması sonsuz olsun mu 
                                  ValidateLifetime=true,
                                  //TODO:zaman farkı olusmasın
                                  ClockSkew = TimeSpan.Zero
                              };
                          });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
