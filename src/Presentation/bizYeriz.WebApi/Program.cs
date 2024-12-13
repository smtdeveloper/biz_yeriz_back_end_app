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

app.UseSwagger(c =>
{
    c.RouteTemplate = "api/swagger/{documentName}/swagger.json"; 
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