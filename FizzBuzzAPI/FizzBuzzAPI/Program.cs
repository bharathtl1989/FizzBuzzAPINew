using FizzBuzzAPI.Factory.FactoryClass;
using FizzBuzzAPI.Factory.Interface;
using FizzBuzzAPI.Services.Interface;

var builder = WebApplication.CreateBuilder(args);
// Register the FizzBuzzServiceFactory with the DI container
builder.Services.AddSingleton<IFizzBuzzServiceFactory, FizzBuzzServiceFactory>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
