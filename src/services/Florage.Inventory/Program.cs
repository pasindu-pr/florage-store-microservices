using Florage.Inventory.AsyncServices;
using Florage.Inventory.Contracts;
using Florage.Inventory.Services;
using Florage.Shared.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductsService>();
builder.Services.AddSingleton<IProductsMessagingService, ProductsMessagingService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

PersistanceConfigurations.AddMongoDb(builder.Services);
AsyncMessagingConfigurations.AddRabbitMq(builder.Services);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
