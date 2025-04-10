using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MyAspNetApp.Data;
using MyAspNetApp.Middleware;
using MyAspNetApp.Services;

var builder = WebApplication.CreateBuilder(args);


// Add controllers for API endpoints
builder.Services.AddControllers();

// Add DbContext for SQLite database
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=products.db"));

// Register ProductService for Dependency Injection
builder.Services.AddScoped<IProductService, ProductService>();

// Register OpenAPI/Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Products API", Version = "v1" });
});

var app = builder.Build();

// Create the database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Use custom error handler middleware
app.UseMiddleware<ErrorHandlerMiddleware>();

// Enable Swagger and Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Products API v1");
    c.RoutePrefix = string.Empty;  // Serve Swagger UI at the root (optional)
});

app.UseHttpsRedirection();
app.UseAuthorization();

// Map controllers
app.MapControllers();

// Run the application
app.Run();
