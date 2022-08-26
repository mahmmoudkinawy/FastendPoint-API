var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddDbContext<AmazonDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseAuthorization();

app.UseFastEndpoints();

await app.RunAsync();
