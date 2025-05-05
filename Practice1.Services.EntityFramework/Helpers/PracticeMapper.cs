using Practice1.Services.EntityFramework.Entities;
using Practice1.Services.Repositories;
using RepoUser = Practice1.Services.Repositories.User;
using EntityUser = Practice1.Services.EntityFramework.Entities.User;

namespace Practice1.Services.EntityFramework.Helpers
{
    public static class PracticeMapper
    {
        public static RepoUser MapUser(EntityUser user)
        {
            return new RepoUser()
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                IsVerified = user.VerifiedUser != null,
                FriendsCount = user.Friends.Count + user.FriendOf.Count,

                PostTypes = user.Posts.Select(p => p.Type).ToList(),

                LikedPostTypes = user.Likes
                    .Select(l => l.Post.Type)
                    .Distinct()
                    .ToList(),

                FriendUsernames = user.Friends
                    .Where(f => f.Friend != null)
                    .Select(f => f.Friend.Username)
                    .Concat(
                        user.FriendOf
                        .Where(f => f.User != null)
                        .Select(f => f.User.Username)
                        )
                    .Distinct()
                    .ToList()
            };
        }
    }
}
