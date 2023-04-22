using Florage.Authentication.ConfigurationsRegistration;
using Florage.Authentication.Contracts;
using Florage.Authentication.Services; 
using Florage.Shared.Configurations;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); 
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddTransient<IUserService, UserService>(); 

RegisterIdentity.ConfigureIdentityServices(builder.Services, builder.Configuration);
SwaggerAuthorizationConfigurations.AddSwaggerAuth(builder.Services, builder.Configuration);
JwtConfiguration.AddJwtAuth(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();