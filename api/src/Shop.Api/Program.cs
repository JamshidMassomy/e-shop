
using Boilerplate.Api.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);


// builder.Services.AddScoped<ExceptionHandlerMiddleware>();




builder.Services.AddAuthSetup(builder.Configuration);
builder.Services.AddControllers(
    options =>
    {
        options.AllowEmptyInputInBodyModelBinding = true;

    });
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
