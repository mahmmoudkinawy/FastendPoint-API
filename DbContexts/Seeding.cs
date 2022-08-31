namespace API.DbContexts;
public static class Seeding
{
    public static async Task SeedProducts(AmazonDbContext context)
    {
        if (await context.Products.AnyAsync()) return;

        var productEntityFaker = new Faker<ProductEntity>("ar")
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Created, f => DateTime.UtcNow)
            .RuleFor(p => p.CountInStock, f => f.Commerce.Random.Int(0, 350))
            .RuleFor(p => p.Price, f => Convert.ToDouble(
                    f.Commerce.Price(min: 0, max: 1_0000, decimals: 4)));

        foreach (var product in productEntityFaker.Generate(50))
        {
            context.Products.Add(product);
            await context.SaveChangesAsync();
        }
    }
}
