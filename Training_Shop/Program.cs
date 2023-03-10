using Microsoft.EntityFrameworkCore;
using Training_Shop.Application.Common.Interfaces.Authentication;
using Training_Shop.Application.Common.Interfaces.Persistence;
using Training_Shop.Data;
using Training_Shop.Infrastructure.Authentication;
using Training_Shop.Infrastructure.Persistence;
using Training_Shop.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                        providerOptions => { providerOptions.EnableRetryOnFailure(); });
    options.LogTo(Console.WriteLine);
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
});

builder.Services.AddScoped<Training_Shop.Application.Services.Authentication.IAuthenticationService, Training_Shop.Application.Services.Authentication.AuthenticationService>();
builder.Services.AddSingleton<IJwtTokenGenerator,JwtTokenGenerator>();
builder.Services.AddTransient<IProductRepository,ProductRepository>();
builder.Services.AddScoped<DapperContext>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
