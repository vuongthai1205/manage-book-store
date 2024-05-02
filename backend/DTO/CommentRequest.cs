namespace backend;
public class CommentRequest
{
    public int BookId { get; set; } // Khóa ngoại
    public string Username { get; set; }
    public string Content { get; set; }
    public CommentRequest()
    {

    }
}