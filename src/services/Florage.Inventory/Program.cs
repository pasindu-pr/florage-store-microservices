using Florage.Inventory.AsyncServices.Producers;
using Florage.Inventory.Contracts;
using Florage.Inventory.Services;
using Florage.Shared.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductsService>();
builder.Services.AddScoped<IProductsMessagingService, ProductsMessagingService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

PersistanceConfigurations.AddMongoDb(builder.Services);
AsyncMessagingConfigurations.AddRabbitMq(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseSwagger(c =>
{
    c.RouteTemplate = "api/inventory/docs/swagger/{documentName}/swagger.json";
});
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "api/inventory/docs";
    c.SwaggerEndpoint("/api/inventory/docs/swagger/v1/swagger.json", "Inventory API");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
