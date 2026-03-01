using Microsoft.AspNetCore.Mvc;

namespace ApiService.Controllers;

[ApiController]
// we want to use [controller] because it becomes a token, which c# will replace in the implementation
[Route("[controller]")]
public class PostsController : ControllerBase
{
    [HttpGet(Name = "GetPosts")]
    public IEnumerable<Post> Get()
    {
        string[] titles = ["awesome c++ guide", "competitive programming", "duckies"];
        return Enumerable.Range(1, titles.GetLength(0)).Select(index => new Post
        {
            Title = titles[index-1],
            Slug = "xx"
        })
        .ToArray();
    }


}
