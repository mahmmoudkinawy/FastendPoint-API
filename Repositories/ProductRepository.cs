namespace API.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly AmazonDbContext _context;

    public ProductRepository(AmazonDbContext context)
    {
        _context = context;
    }

    public async Task AddProduct(ProductEntity product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<ProductEntity>> GetAllProductsAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<ProductEntity> GetProductByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task RemoveProduct(ProductEntity product)
    {
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateProduct(ProductEntity product)
    {
        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}
