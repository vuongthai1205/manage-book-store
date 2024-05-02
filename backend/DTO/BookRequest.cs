namespace backend;
public class BookRequest
{
    public string? Title { get; set; }
    public string? Author { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    // Constructor
    public BookRequest()
    {
    }
}