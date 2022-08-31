namespace API.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly AmazonDbContext _context;
    private readonly IMapper _mapper;

    public ProductRepository(AmazonDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddProduct(ProductEntity product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task<PagerModel<ProductResponse>> GetAllProductsAsync(
        PaginationParams paginationParams)
    {
        var query = _context.Products.AsQueryable();

        return await PagerModel<ProductResponse>.CreateAsync(
            query.ProjectTo<ProductResponse>(_mapper.ConfigurationProvider),
            paginationParams.PageNumber,
            paginationParams.PageSize);
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
