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
    o.Filters.Add(typeof(ApiExceptionAttribute)));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextFactory<ResultsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ResultsConnectionString")));
builder.Services.AddDbContext<IResultsContext, ResultsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ResultsConnectionString")));

builder.Services.AddSingleton(Channel.CreateUnbounded<Log>(new UnboundedChannelOptions { SingleReader = true}));
builder.Services.AddSingleton(x => x.GetRequiredService<Channel<Log>>().Reader);
builder.Services.AddSingleton(x => x.GetRequiredService<Channel<Log>>().Writer);
builder.Services.AddSingleton<ILogWriter, LogWriter>();
builder.Services.AddHostedService<LoggingService>();

builder.Services.AddScoped<IPasswordEncryptionService, PasswordEncryptionService>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer();
builder.Services.ConfigureOptions<JwtOptionsSetup>();
builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
