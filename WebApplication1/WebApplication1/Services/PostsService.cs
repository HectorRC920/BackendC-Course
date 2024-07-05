using System.Text.Json;
using WebApplication1.DTO;

namespace WebApplication1.Services
{
    public class PostsService : IPostsService
    {
        private HttpClient _httpClient;

        public PostsService(HttpClient httpClient)
        {
            _httpClient = httpClient ;
        }
        public async Task<IEnumerable<PostDTO>> Get()
        {
            Console.WriteLine("olasdas",_httpClient.BaseAddress);
            HttpResponseMessage result = await  _httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
            string body = await result.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions()
            { 
                PropertyNameCaseInsensitive = true,
            };
            var post = JsonSerializer.Deserialize<IEnumerable<PostDTO>>(body,options);

            return post;
        }
    }
} 
