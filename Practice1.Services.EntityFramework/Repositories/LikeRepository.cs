using Microsoft.EntityFrameworkCore;
using Practice1.Services.EntityFramework.Entities;
using Practice1.Services.Repositories;
using Practice1.Services.Exceptions;
using RepoLike = Practice1.Services.Repositories.Like;
using Practice1.Services.EntityFramework.Helpers;

namespace Practice1.Services.EntityFramework.Repositories
{
    public sealed class LikeRepository : ILikeRepository
    {
        private readonly PracticeContext _context;

        public LikeRepository(PracticeContext context)
        {
            _context = context;
        }

        public async Task<IList<RepoLike>> GetAllLikes()
        {
            try
            {
                var likes = await _context.Likes
                    .Include(l => l.User)
                    .Include(l => l.Post)
                    .ToListAsync();

                return likes.Select(PracticeMapper.MapLike).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving all likes: {ex.Message}", ex);
            }
        }


        public async Task<RepoLike> GetLikeByIdAsync(int id)
        {
            try
            {
                var like = await _context.Likes
                    .Include(l => l.User)
                    .Include(l => l.Post)
                    .FirstOrDefaultAsync(l => l.Id == id);

                if (like == null)
                {
                    throw new LikeNotFoundException($"Like with {id} not found");
                }

                return PracticeMapper.MapLike(like);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the like by id: {ex.Message}", ex);
            }
        }

        public async Task<RepoLike> GetLikeByPostId(int postId)
        {
            try
            {
                var like = await _context.Likes
                    .Include(l => l.User)
                    .Include(l => l.Post)
                    .FirstOrDefaultAsync(l => l.PostId == postId);

                if (like == null)
                {
                    throw new LikeNotFoundException($"Like with {postId} not found");
                }

                return PracticeMapper.MapLike(like);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the like by email: {ex.Message}", ex);
            }
        }

        public async Task<IList<RepoLike>> GetLikesByUserId(int userId)
        {
            try
            {
                var likes = await _context.Likes
                    .Include(l => l.User)
                    .Include(l => l.Post)
                    .Where(l => l.UserId == userId)
                    .ToListAsync();

                if (!likes.Any())
                {
                    throw new LikeNotFoundException($"No likes found for user with ID {userId}.");
                }

                return likes.Select(like => new RepoLike
                {
                    Id = like.Id,
                    UserId = like.UserId,
                    User = PracticeMapper.MapUser(like.User),
                    PostId = like.PostId,
                    Post = PracticeMapper.MapPost(like.Post),
                    CreatedAt = like.CreatedAt,
                    UpdatedAt = like.UpdatedAt
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving likes by user ID: {ex.Message}", ex);
            }
        }

    }
}
