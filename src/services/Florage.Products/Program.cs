using Florage.Products.AsyncServices;
using Florage.Products.Contracts;
using Florage.Products.Services;
using Florage.Shared.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddSingleton<IEventProcessor, EventProcessor>();
builder.Services.AddHostedService<MessageBusSubscriber>();

PersistanceConfigurations.AddMongoDb(builder.Services);
AsyncMessagingConfigurations.AddRabbitMq(builder.Services);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(); 

app.UseHttpsRedirection();

app.UseCors(policy => policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
