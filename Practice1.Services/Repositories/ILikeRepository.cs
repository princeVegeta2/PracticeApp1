using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Services.Repositories
{
    public interface ILikeRepository
    {
        /// <summary>
        /// Gets a like by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Like> GetLikeByIdAsync(int id);

        /// <summary>
        /// Get all likes by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<IList<Like>> GetLikesByUserId(int userId);

        /// <summary>
        /// Get a like by its post id
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        Task<Like> GetLikeByPostId(int postId);

        /// <summary>
        /// Get all likes
        /// </summary>
        /// <returns></returns>
        Task<IList<Like>> GetAllLikes();
    }
}
