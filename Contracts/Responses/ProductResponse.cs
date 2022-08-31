namespace API.Contracts.Responses;
public class ProductResponse
{
    public int Id { get; set; }
    public DateTime Created { get; set; } 
    public string Name { get; set; }
    public double Price { get; set; }
    public int CountInStock { get; set; }
}
