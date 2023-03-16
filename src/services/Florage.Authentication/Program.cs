using Florage.Authentication.Configurations;
using Florage.Authentication.ConfigurationsRegistration;
using Florage.Authentication.Contracts;
using Florage.Authentication.Services;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  
builder.Services.AddScoped<IUserService, UserService>();

JwtConfiguration.JwtConfigurationRegistration(builder.Services, builder.Configuration);
RegisterIdentity.ConfigureIdentityServices(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
