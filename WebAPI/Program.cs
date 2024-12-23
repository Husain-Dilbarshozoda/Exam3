using Infrastructure.DataContaxt;
using Infrastructure.Interfaces;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IProductsService, ProductsService>();
builder.Services.AddScoped<IConTaxt, ConTaxt>();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", ":)"));
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
