using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Services.Repositories
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; init; }
        public required User User { get; init; }
        public string Type { get; set; }
        public int TotalLikes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Like> Likes { get; set; } = new List<Like>();
    }
}
