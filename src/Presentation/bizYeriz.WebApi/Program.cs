using bizyeriz.Application;
using bizYeriz.Persistence;
using bizYeriz.WebApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationServices();

// Register middleware
builder.Services.AddScoped<ExceptionHandlingMiddleware>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceService(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    // Swagger JSON endpoint
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "BizYeriz API V1");
    
    // Change the base path for the Swagger UI
    c.RoutePrefix = "api/swagger";
});

app.UseMiddleware<ExceptionHandlingMiddleware>();

/*app.UseHttpsRedirection()*/
; // htpps zorunu yapar!

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();