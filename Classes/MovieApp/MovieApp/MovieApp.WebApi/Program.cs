using MovieApp.Helpers.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("MovieAppDbConnection");
builder.Services.InjectDbContext(connectionString)
                .InjectRepositories()
                .InjectServices()
                .InjectAutoMapper()
                .InjectFluentValidator();

builder.Services.AddCors(options => options.AddPolicy("myPolicy", policy => policy.AllowAnyOrigin()));


var app = builder.Build();
app.UseCors("myPolicy");
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
