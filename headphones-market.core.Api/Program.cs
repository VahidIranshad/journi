using Headphones.Domain.Base;
using headphones_market.core.Api.Extensions;
using Headphones.Application;
using Headphones.Persistence;
using headphones_market.core.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);


ConfigurationManager configuration = builder.Configuration;
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureInfrastructureServices(configuration);
builder.Services.ConfigureApplicationServices();

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
app.UseMiddleware<ExceptionMiddleware>();

app.Run();
public partial class Program { }
