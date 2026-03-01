namespace ApiService;

public class Post 
{
    required public string Title { get; set; }
    required public string Slug { get; set; }
    public string? Body { get; set; }
}
