using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions; 
namespace ApiService.Tests;
public class UnitTest1 : WebApplicationFactory<Program>
{
    private readonly ITestOutputHelper _output;
    public UnitTest1(ITestOutputHelper _output) {
        this._output = _output;
    }

    [Fact]
    public async Task Test1()
    {
        var client = CreateClient();
        var response = await client.GetAsync("/todos");
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetPostsReturnsSuccess()
    {
        var client = CreateClient();
        var response = await client.GetAsync("/posts");
        response.EnsureSuccessStatusCode();
    }

    [Fact, Trait("Selected", "1")]
    public async Task PostInsertsPostIntoDatabase()
    {
        var client = CreateClient();
        var newPost = new Post
        {
            Title = "hello",
            Slug = "slug"
        };
        var response = await client.PostAsync("/posts", JsonContent.Create(newPost));
        response.EnsureSuccessStatusCode();

        response = await client.GetAsync("/posts");
        var posts = await response.Content.ReadFromJsonAsync<List<Post>>();
        posts.Should().NotBeNull();
        
    }
}
