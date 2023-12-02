using System.Diagnostics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using ResultsApi.Authentication;
using ResultsApi.Data;
using ResultsApi.Logging;
using ResultsApi.Models;
using ResultsApi.OptionsSetup;
using ResultsApi.Services;
using System.Threading.Channels;
using ResultsApi.ErrorHandling;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(o => 
    o.Filters.Add(typeof(ApiExceptionFilter)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContextFactory<ResultsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ResultsConnectionString")));
builder.Services.AddDbContext<IResultsContext, ResultsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ResultsConnectionString")));

builder.Services.AddSingleton(Channel.CreateUnbounded<Log>(new UnboundedChannelOptions { SingleReader = true }));
builder.Services.AddSingleton(x => x.GetRequiredService<Channel<Log>>().Reader);
builder.Services.AddSingleton(x => x.GetRequiredService<Channel<Log>>().Writer);
builder.Services.AddSingleton<ILogWriter, LogWriter>();
builder.Services.AddHostedService<LoggingService>();

builder.Services.AddScoped<PasswordEncryptionService>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("cors", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("cors");

await using var scope = app.Services.CreateAsyncScope();
var db = scope.ServiceProvider.GetRequiredService<ResultsContext>();
await db.Database.MigrateAsync();
await db.Seed();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program{}
