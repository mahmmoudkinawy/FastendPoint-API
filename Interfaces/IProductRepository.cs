namespace API.Interfaces;
public interface IProductRepository
{
    Task<PagerModel<ProductResponse>> GetAllProductsAsync(PaginationParams paginationParams);
    Task<ProductEntity> GetProductByIdAsync(int id);
    Task AddProduct(ProductEntity product);
    Task RemoveProduct(ProductEntity product);
    Task UpdateProduct(ProductEntity product);
}
