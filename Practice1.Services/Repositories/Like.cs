using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Services.Repositories
{
    public class Like
    {
        public int Id { get; set; }

        public int UserId { get; init; }

        public required User User { get; init; }

        public int PostId { get; init; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
