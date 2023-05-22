using GGApi.Models.DB;
using GGApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<GeoguesserDatabaseSettings>(
    builder.Configuration.GetSection("GeoguesserDatabase"));

builder.Services.AddSingleton<LocationService>();
builder.Services.AddSingleton<ScoreboardService>();

// Add services to the container.

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


// TODO: https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-7.0&tabs=visual-studio
// https://www.mongodb.com/developer/languages/csharp/create-restful-api-dotnet-core-mongodb/