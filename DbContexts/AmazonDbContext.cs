namespace API.DbContexts;
public class AmazonDbContext : DbContext
{
    public AmazonDbContext(DbContextOptions<AmazonDbContext> options) : base(options)
    { }

    public DbSet<ProductEntity> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductEntity>()
            .HasData(
                new ProductEntity
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 15000.5,
                    CountInStock = 11
                },
                new ProductEntity
                {
                    Id = 2,
                    Name = "Mobile",
                    Price = 16000.5,
                    CountInStock = 123
                },
                new ProductEntity
                {
                    Id = 3,
                    Name = "Moza",
                    Price = 13600.3,
                    CountInStock = 43
                }
            );

    }
}
