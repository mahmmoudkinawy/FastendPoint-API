namespace API.Contracts.Requests;
public class UpdateProductRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int CountInStock { get; set; }
}
