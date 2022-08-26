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

await app.RunAsync();
