using bizyeriz.Application;
using bizyeriz.Application.Features.Auths.Commands.RegisterUser;
using bizYeriz.Persistence;
using bizYeriz.Shared.Security.Encryption;
using bizYeriz.Shared.Security.JWT;
using bizYeriz.WebApi.Middlewares;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// FluentValidation için tüm validatorlarý kaydet
builder.Services.AddValidatorsFromAssembly(typeof(RegisterCustomerCommandValidator).Assembly);

// Diðer baðýmlýlýklarý kaydet
const string tokenOptionsConfigurationSection = "TokenOptions";
TokenOptions tokenOptions =
    builder.Configuration.GetSection(tokenOptionsConfigurationSection).Get<TokenOptions>()
    ?? throw new InvalidOperationException($"\"{tokenOptionsConfigurationSection}\" section cannot found in configuration.");

builder.Services.AddApplicationServices();

// Register middleware
builder.Services.AddScoped<ExceptionHandlingMiddleware>();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceService(builder.Configuration);


builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));

// JWT Authentication'ý ekle
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });


// Policy tabanlý yetkilendirme
builder.Services.AddAuthorization(options =>
{
    //CompanyPolicy
    options.AddPolicy("AddCompany", policy =>
        policy.RequireClaim("Permission", "AddCompany"));

    options.AddPolicy("UpdateCompany", policy =>
        policy.RequireClaim("Permission", "UpdateCompany"));

    options.AddPolicy("DeleteCompany", policy =>
        policy.RequireClaim("Permission", "DeleteCompany"));

    // FoodPolicy 
    options.AddPolicy("AddFood", policy =>
        policy.RequireClaim("Permission", "AddFood"));

    options.AddPolicy("UpdateFood", policy =>
        policy.RequireClaim("Permission", "UpdateFood"));

    options.AddPolicy("DeleteFood", policy =>
        policy.RequireClaim("Permission", "DeleteFood"));

    //CuisineCategoryPoliy

});

var app = builder.Build();

app.UseSwagger(c =>
{
    c.RouteTemplate = "/api/swagger/{documentName}/swagger.json"; 
});
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "BizYeriz API V1");
    c.RoutePrefix = "api/swagger";
});

app.UseMiddleware<ExceptionHandlingMiddleware>();

/*app.UseHttpsRedirection()*/
; // htpps zorunu yapar!

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();