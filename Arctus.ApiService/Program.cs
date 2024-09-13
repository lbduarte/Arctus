using Arctus.ApiService.DbContexts;
using Arctus.ApiService.Helpers;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddNpgsqlDbContext<ArctusContext>("postgresdb");

builder.Services.AddControllers();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();
app.MapControllers();

app.MapDefaultEndpoints();

var context = app.Services.CreateScope().ServiceProvider
    .GetRequiredService<ArctusContext>();
DatabaseHelper.Seed(context);

app.Run();
