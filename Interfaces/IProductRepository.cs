namespace API.Interfaces;
public interface IProductRepository
{
    Task<IReadOnlyList<ProductEntity>> GetAllProductsAsync();
    Task<ProductEntity> GetProductByIdAsync(int id);
    Task AddProduct(ProductEntity product);
    Task RemoveProduct(ProductEntity product);
    Task UpdateProduct(ProductEntity product);
}
