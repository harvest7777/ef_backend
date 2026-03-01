namespace ApiService;

public class Todo 
{
    public DateOnly Date { get; set; }
    required public string Title { get; set; }
    public string? Summary { get; set; }
}
