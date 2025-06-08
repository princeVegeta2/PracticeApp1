using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Services.Repositories
{
    public interface IPostRepository
    {
        Task<Post> GetPostByIdAsync(int id);

        Task<IList<Post>> GetPostsByUserIdAsync(int userId);

        Task<Post> GetPostByLikeId(int likeId);

        Task<IList<Post>> GetAllPosts();
    }
}
