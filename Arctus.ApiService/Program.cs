using Arctus.ApiService.DbContexts;
using Arctus.ApiService.Helpers;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
builder.AddNpgsqlDbContext<ArctusContext>(connectionName: "postgresdb");

builder.Services.AddControllers();
builder.Services.AddProblemDetails();

builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc(name: "v1", new OpenApiInfo
    {
        Title = "Arctus",
        Version = "v1"
    });
});

var app = builder.Build();

app.UseExceptionHandler();
app.MapControllers();
app.MapDefaultEndpoints();

app.UseSwagger();
app.UseSwaggerUI(options => {
    options.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Arctus");
});

var context = app.Services.CreateScope().ServiceProvider
    .GetRequiredService<ArctusContext>();
DatabaseHelper.Seed(context);

app.Run();
