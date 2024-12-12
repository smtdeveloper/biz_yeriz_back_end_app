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
app.UseSwaggerUI();

app.UseMiddleware<ExceptionHandlingMiddleware>();

/*app.UseHttpsRedirection()*/
; // htpps zorunu yapar!

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();