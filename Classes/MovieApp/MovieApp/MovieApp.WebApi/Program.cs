using MovieApp.Helpers.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("MovieAppDbConnection");
builder.Services.InjectDbContext(connectionString)
                .InjectRepositories()
                .InjectServices()
                .InjectAutoMapper()
                .InjectFluentValidator();

// HANDLING CORS RESTRICTIONS
builder.Services.AddCors(options => options.AddPolicy("myPolicy", policy => policy.AllowAnyOrigin()));


var app = builder.Build();
app.UseCors("myPolicy");  // using cors policy created on l.18

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
