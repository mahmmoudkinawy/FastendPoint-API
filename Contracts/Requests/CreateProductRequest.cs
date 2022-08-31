namespace API.Contracts.Requests;
public class CreateProductRequest
{
    public string Name { get; set; }

    public double Price { get; set; }

    public int CountInStock { get; set; }
}
