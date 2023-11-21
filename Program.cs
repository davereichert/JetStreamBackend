using JetStreamBackend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
    .Enrich.FromLogContext());




var key = Encoding.ASCII.GetBytes("ilhsdofhnfeudjsdjliuuejdklssahsdmWfd");

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
 {
     x.RequireHttpsMetadata = false;
     x.SaveToken = true;
     x.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuerSigningKey = true,
         IssuerSigningKey = new SymmetricSecurityKey(key),
         ValidateIssuer = false,
         ValidateAudience = false
     };
 });

builder.Services.AddScoped<JetStreamBackend.Service.ServiceAuftragService>();
builder.Services.AddScoped<JetStreamBackend.Service.MitarbeiterService>();


builder.Services.AddControllers();

// Registriere deinen DbContext
builder.Services.AddDbContext<SkiServiceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonDateTimeConverter());
});

// Swagger-Konfiguration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS-Konfiguration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhostDevelopment",
        builder =>
        {
            builder.WithOrigins("https://localhost:7106") // Ersetze PORT mit dem Port deines Frontend-Servers
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.UseStaticFiles();


app.UseCors("AllowLocalhostDevelopment");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
