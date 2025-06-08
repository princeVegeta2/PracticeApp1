using Microsoft.EntityFrameworkCore;
using Practice1.Services.EntityFramework.Entities;
using Practice1.Services.Repositories;
using Practice1.Services.Exceptions;
using RepoPost = Practice1.Services.Repositories.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Practice1.Services.EntityFramework.Helpers;

namespace Practice1.Services.EntityFramework.Repositories
{
    public sealed class PostRepository : IPostRepository
    {
        private readonly PracticeContext _context;

        public PostRepository(PracticeContext context)
        {
            _context = context;
        }
        public async Task<IList<Post>> GetAllPosts()
        {
            try
            {
                var posts = await _context.Posts
                    .Include(p => p.User)
                    .Include(p => p.Likes)
                    .ToListAsync();

                if (!posts.Any())
                {
                    throw new PostNotFoundException($"No posts found");
                }

                return posts.Select(post => new RepoPost
                {
                    Id = post.Id,
                    UserId = post.UserId,
                    User = PracticeMapper.MapUser(post.User),
                    Type = post.Type,
                    TotalLikes = post.TotalLikes,
                    CreatedAt = post.CreatedAt,
                    UpdatedAt = post.UpdatedAt,
                    Likes = post.Likes.Select(like => PracticeMapper.MapLike(like)).ToList()
                }).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving all posts: {ex.Message}", ex);
            }
        }

        public async Task<Post> GetPostByIdAsync(int id)
        {
            try
            {
                var post = await _context.Posts
                    .Include(p => p.User)
                    .Include(p => p.Likes)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (post == null)
                {
                    throw new PostNotFoundException($"Post with ID {id} not found");
                }

                return PracticeMapper.MapPost(post);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the post by id: {ex.Message}", ex);
            }
        }

        public async Task<Post> GetPostByLikeId(int likeId)
        {
            try
            {
                var post = await _context.Posts
                    .Include(p => p.User)
                    .Include(p => p.Likes)
                    .FirstOrDefaultAsync(p => p.Likes.Any(l => l.Id == likeId));

                if (post == null)
                {
                    throw new PostNotFoundException($"Post with like ID {likeId} not found");
                }

                return PracticeMapper.MapPost(post);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving the post by like ID: {ex.Message}", ex);
            }
        }

        public Task<IList<Post>> GetPostsByUserIdAsync(int userId)
        {
            try
            {
                var posts = _context.Posts
                    .Include(p => p.User)
                    .Include(p => p.Likes)
                    .Where(p => p.UserId == userId)
                    .ToListAsync();

                if (!posts.Result.Any())
                {
                    throw new PostNotFoundException($"No posts found for user with ID {userId}.");
                }

                return posts.Select(post => new RepoPost
                {

                })
        }
    }
}
