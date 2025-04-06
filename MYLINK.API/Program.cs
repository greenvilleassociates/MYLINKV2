using somecontrollers.Controllers;
using Enterprise.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Services;
using System.Text;
var builder = WebApplication.CreateBuilder(args);

// Register Service Bus Service
builder.Services.AddSingleton<ServiceBusService>();

//  Read JWT settings from appsettings.json
var jwtKey = builder.Configuration["Jwt:Key"];
var jwtIssuer = builder.Configuration["Jwt:Issuer"];
var jwtAudience = builder.Configuration["Jwt:Audience"];

if (string.IsNullOrEmpty(jwtKey) || string.IsNullOrEmpty(jwtIssuer) || string.IsNullOrEmpty(jwtAudience))
{
    throw new InvalidOperationException("JWT configuration is missing in appsettings.json");
}

//  Add JWT Authentication to the services
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
        };
    });

//  Add Authorization Services
builder.Services.AddAuthorization();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseAuthorization();
app.MapEmployeeEndpoints();
app.MapBuEndpoints();
app.MapLearndetailEndpoints();
app.MapGEMEndpoints();
app.MapResdetailEndpoints();
app.MapCertificationEndpoints();
app.MapUserlogEndpoints();
app.MapUserprofileEndpoints();
app.MapUserEndpoints();
app.MapUseractionEndpoints();
app.MapUserhelpEndpoints();
app.MapUsersessionEndpoints();
app.MapControllers();
app.MapAuthEndpoints();
app.MapBatchEndpoints();
app.MapBatchtypeEndpoints();
app.MapCerttypeEndpoints();
app.MapCertrequirementsEndpoints();
app.MapCertcalogueEndpoints();
app.MapManagerEndpoints();
app.MapStoreEndpoints();
app.MapRegionEndpoints();
app.MapCompanyEndpoints();
app.Run();
