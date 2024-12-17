using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

#if(EnableSwaggerSupport)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MicroserviceVsixTemplate", Version = "v1" });
});
#endif
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
#if (EnableSwaggerSupport)
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MicroserviceVsixTemplate v1");
        options.RoutePrefix = string.Empty; // Swagger as the root page
    });
#endif
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
