using Florage.Authentication.AsyncMessagingServices;
using Florage.Authentication.ConfigurationsRegistration;
using Florage.Authentication.Contracts;
using Florage.Authentication.Services; 
using Florage.Shared.Configurations;

var builder = WebApplication.CreateBuilder(args); 

builder.Services.AddControllers(); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUsersPublishingService, UsersPublishingService>();

AsyncMessagingConfigurations.AddRabbitMq(builder.Services, builder.Configuration);
RegisterIdentity.ConfigureIdentityServices(builder.Services, builder.Configuration);
SwaggerAuthorizationConfigurations.AddSwaggerAuth(builder.Services, builder.Configuration);
JwtConfiguration.AddJwtAuth(builder.Services, builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();