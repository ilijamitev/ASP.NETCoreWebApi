using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Notes.Common.Models;
using Notes.DependencyInjection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthorization();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// Program.cs DA BIDE POCISTO I CITKO
// VO POSEBEN SERVIS I SAMO DA SE INJEKTIRAAT => PRIMER VO DependencyInjection => SwaggerConfiguration.cs
builder.Services.AddSwaggerGen(
               c =>
               {
                   c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                   {
                       Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                          Enter 'Bearer' [space] and then your token in the text input below.
                          \r\n\r\nExample: 'Bearer 12345abcdef'",
                       Name = "Authorization",
                       In = ParameterLocation.Header,
                       Type = SecuritySchemeType.ApiKey,
                       Scheme = "Bearer"
                   });

                   c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                     {
                        {
                          new OpenApiSecurityScheme
                          {
                            Reference = new OpenApiReference
                              {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,

                            },
                            new List<string>()
                          }
                       });
               });

// Configuring MyAppSettings section
var appConfig = builder.Configuration.GetSection("MyAppSettings");

// Using MyAppSettings 
var appSettings = appConfig.Get<MyAppSettings>();

builder.Services.AddOptions<MyAppSettings>().Bind(appConfig);
//to use this => IOptions<MyAppSettings>


var secret = Encoding.ASCII.GetBytes(appSettings.Secret);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}
).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secret),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services
    .ServicesDependencies()
    .RegisterDataDependencies()
    .RegisterDbContext(appSettings.NotesAppConnectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
