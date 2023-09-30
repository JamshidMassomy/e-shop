
using AspNetCoreRateLimit;
using Boilerplate.Api.Configurations;
using Shop.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddInMemoryRateLimiting();
builder.Services.AddRateLimiterConfiguration();
builder.Services.AddAuthSetup(builder.Configuration);
builder.Services.AddControllers(
    options =>
    {
        options.AllowEmptyInputInBodyModelBinding = true;

    });
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddApplicationSetup();
builder.Services.AddPersistenceSetup(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerSetup();
builder.Services.AddPersistenceSetup(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddMediatRSetup();
builder.Services.AddMvcCore();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


var app = builder.Build();
app.UseIpRateLimiting();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAnyOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseSwaggerSetup();
app.MapControllers();


await app.Migrate();
await app.RunAsync();
