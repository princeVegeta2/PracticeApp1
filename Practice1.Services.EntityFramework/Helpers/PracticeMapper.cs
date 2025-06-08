using Practice1.Services.EntityFramework.Entities;
using Practice1.Services.Repositories;
using RepoUser = Practice1.Services.Repositories.User;
using RepoLike = Practice1.Services.Repositories.Like;
using RepoPost = Practice1.Services.Repositories.Post;
using EntityUser = Practice1.Services.EntityFramework.Entities.User;

namespace Practice1.Services.EntityFramework.Helpers
{
    public static class PracticeMapper
    {
        public static RepoUser MapUser(EntityUser user)
        {
            return new RepoUser
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                IsVerified = user.VerifiedUser != null,
                FriendsCount = user.Friends.Count + user.FriendOf.Count,
                PostTypes = new(),
                LikedPostTypes = new(),
                FriendUsernames = new()
            };
        }

        public static RepoLike MapLike(Entities.Like like)
        {
            return new RepoLike
            {
                Id = like.Id,
                UserId = like.UserId,
                User = MapUser(like.User), 
                PostId = like.PostId,
                Post = new RepoPost
                {
                    Id = like.Post.Id,
                    UserId = like.Post.UserId,
                    User = MapUser(like.Post.User), 
                    Type = like.Post.Type,
                    TotalLikes = like.Post.TotalLikes,
                    CreatedAt = like.Post.CreatedAt,
                    UpdatedAt = like.Post.UpdatedAt
                },
                CreatedAt = like.CreatedAt,
                UpdatedAt = like.UpdatedAt
            };
        }

        public static RepoPost MapPost(Entities.Posts post)
        {
            return new RepoPost
            {
                Id = post.Id,
                UserId = post.UserId,
                User = MapUser(post.User), 
                Type = post.Type,
                TotalLikes = post.TotalLikes,
                CreatedAt = post.CreatedAt,
                UpdatedAt = post.UpdatedAt,
                Likes = post.Likes.Select(MapLike).ToList() 
            };
        }
    }
}
