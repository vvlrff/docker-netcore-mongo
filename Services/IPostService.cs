using dockerForum.Models;

namespace dockerForum.Services
{
    public interface IPostService
    {
        List<Post> Get();
        Post Get(string id);
        Post Create(Post post);
        void Update(string id, Post post);
        void Remove(string id);
    }
}
