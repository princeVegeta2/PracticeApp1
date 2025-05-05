using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Services.Repositories
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; init; } = default!;

        public string Email { get; init; } = default!;

        public bool IsVerified { get; init; }

        public int FriendsCount { get; init; }

        public List<string> PostTypes { get; init; } = new();

        public List<string> LikedPostTypes { get; init; } = new();

        public List<string> FriendUsernames { get; init; } = new();
    }
}
