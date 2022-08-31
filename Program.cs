var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

builder.Services.AddSwaggerDoc();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<AmazonDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseOpenApi();

app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.UseAuthorization();

app.UseFastEndpoints();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
try
{
    var dbContext = services.GetRequiredService<AmazonDbContext>();
    await dbContext.Database.MigrateAsync();
    await Seeding.SeedProducts(dbContext);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "There was an error in migrations!");
}

await app.RunAsync();
