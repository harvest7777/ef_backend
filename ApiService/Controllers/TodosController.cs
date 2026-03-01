using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers;

[ApiController]
// we want to use [controller] because it becomes a token, which c# will replace in the implementation
[Route("[controller]")]
public class TodosController : ControllerBase
{
    [HttpGet(Name = "GetTodos")]
    public IEnumerable<Todo> Get()
    {
        string[] titles = ["groceries", "walk the dog", "math homework", "study c#", "codeforces"];
        return Enumerable.Range(1, 5).Select(index => new Todo 
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Title = titles[index-1]
        })
        .ToArray();
    }

    // i think this endpoitn shoudl be capable of posting many todos at the same time 
    // so, we shoudl use the noun todos
    [HttpPost(Name = "PostTodos")]
    // i think it must be called public void Post(Todo todo) {}
    public void Post(Todo[] todos)
    {
        Console.WriteLine("hello!");
        foreach (var todo in todos)
        {
            Console.WriteLine(todo);
        }
        return;
    }

}
