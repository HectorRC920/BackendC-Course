using WebApplication1.DTO;

namespace WebApplication1.Services
{
    public interface IPostsService
    {
        public Task<IEnumerable<PostDTO>> Get();
    }
}
