using bizyeriz.Application;
using bizYeriz.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddApplicationServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceService(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

/*app.UseHttpsRedirection()*/; // htpps zorunu yapar!

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();