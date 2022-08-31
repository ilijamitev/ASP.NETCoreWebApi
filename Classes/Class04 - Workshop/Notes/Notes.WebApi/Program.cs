using Notes.Common.Models;
using Notes.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


// Configuring MyAppSettings section
var appConfig = builder.Configuration.GetSection("MyAppSettings");

// Using MyAppSettings 
var appSettings = appConfig.Get<MyAppSettings>();


builder.Services
    .ServicesDependencies()
    .RegisterDataDependencies()
    .RegisterDbContext(appSettings.NotesAppDbConnection);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
