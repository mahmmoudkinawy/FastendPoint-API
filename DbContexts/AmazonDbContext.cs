namespace API.DbContexts;
public class AmazonDbContext : DbContext
{
    public AmazonDbContext(DbContextOptions<AmazonDbContext> options) : base(options)
    { }

    public DbSet<ProductEntity> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

}
