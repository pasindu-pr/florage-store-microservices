using Florage.Products.Contracts;
using Florage.Products.Services;
using Florage.Shared.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductsService, ProductsService>(); 

PersistanceConfigurations.AddMongoDb(builder.Services);
AsyncMessagingConfigurations.AddRabbitMq(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseSwagger(c =>
{
    c.RouteTemplate = "api/products/docs/swagger/{documentName}/swagger.json";
});
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "api/products/docs";
    c.SwaggerEndpoint("/api/products/docs/swagger/v1/swagger.json", "MY API");
});

app.UseHttpsRedirection();
 
app.UseAuthorization();

app.MapControllers();

app.Run();