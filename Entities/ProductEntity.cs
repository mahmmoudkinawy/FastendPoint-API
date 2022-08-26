namespace API.Entities;
public class ProductEntity
{
    public int Id { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public string Name { get; set; }
    public double Price { get; set; }
    public int CountInStock { get; set; }
}
