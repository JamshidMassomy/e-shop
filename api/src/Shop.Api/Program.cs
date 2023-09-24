
using Boilerplate.Api.Configurations;
using Microsoft.AspNetCore.Diagnostics;
using Shop.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddScoped<ExceptionHandlerMiddleware>();




builder.Services.AddAuthSetup(builder.Configuration);
builder.Services.AddControllers(
    options =>
    {
        options.AllowEmptyInputInBodyModelBinding = true;

    });

builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerSetup();
builder.Services.AddPersistenceSetup(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddMediatRSetup();




var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.UseHttpsRedirection();
app.UseSwaggerSetup();
app.MapControllers();


await app.RunAsync();
