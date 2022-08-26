namespace API.DbContexts;
public class AmazonDbContextFactory : IDesignTimeDbContextFactory<AmazonDbContext>
{
    public AmazonDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AmazonDbContext>();
        optionsBuilder.UseNpgsql("Server=127.0.0.1; Port=5432; User Id=postgres; Password=Pa$$w0rd; Database=ECommerceMinimalFastEndPoint;");

        return new AmazonDbContext(optionsBuilder.Options);
    }
}
