using System.Threading.Channels;
using Microsoft.EntityFrameworkCore;
using ResultsApi.Data;
using ResultsApi.Logging;
using ResultsApi.Models;
using ResultsApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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
